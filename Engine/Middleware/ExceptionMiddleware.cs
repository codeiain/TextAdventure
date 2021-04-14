using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Xml;
using Engine.Constants;
using Engine.Exceptions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;

namespace Engine.Middleware
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate next;
        private readonly ErrorsInformation errorsInformation;

        public ExceptionMiddleware(RequestDelegate next, ErrorsInformation errorsInformation)
        {
            this.next = next;
            this.errorsInformation = errorsInformation;
        }

        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await next(httpContext);
            }
            catch (Exception ex)
            {
                await handleExceptionAsync(httpContext, ex);
            }
        }

        private async Task handleExceptionAsync(HttpContext context, Exception exception)
        {
            context.Response.ContentType = "application/json";
            var errorDetails = prepareErrorDetails(exception);

            context.Response.StatusCode = errorDetails.httpStatusCode ?? setSuitableStatusCode(exception);
            await context.Response.WriteAsync(errorDetails.errorSummary.ToString());
        }

        private int setSuitableStatusCode(Exception exception)
        {
            switch (exception)
            {
                case UnsupportedContentTypeException ex:
                    {
                        return (int)HttpStatusCode.UnsupportedMediaType;
                    }
                case XmlException _:
                    {
                        return (int)HttpStatusCode.UnsupportedMediaType;
                    }
                case DetailedException _:
                    {
                        return (int)HttpStatusCode.InternalServerError;
                    }
                default:
                    {
                        return (int)HttpStatusCode.InternalServerError;
                    }
            }
        }


        private (ErrorSummary errorSummary, int? httpStatusCode) prepareErrorDetails(Exception exception)
        {
            var res = new ErrorSummary() { CorrelationId = Guid.NewGuid().ToString() };
            switch (exception)
            {
                case DetailedException detailedException:
                    {
                        var currentErrorCatalog = errorsInformation.GetErrorCatalogByCode(detailedException.LocationCodePairs.Value);
                        res.Errors = new List<ErrorDetails>
                    {
                        new ErrorDetails()
                        {
                            Location = detailedException.LocationCodePairs.Key,
                            Code = detailedException.LocationCodePairs.Value,
                            Problem = (string.IsNullOrEmpty(detailedException.JsonData) ? currentErrorCatalog.Problem : JsonConvert.DeserializeObject<object>(detailedException.JsonData)),
                            Action = currentErrorCatalog.Action
                        }
                    };

                        return (res, currentErrorCatalog.HttpResponseCode);
                    }
                case XmlException ex1:
                case UnsupportedContentTypeException ex:
                    {
                        ErrorCatalog currentErrorCatalog;
                        string errorLocation;

                            currentErrorCatalog = errorsInformation.GetErrorCatalogByCode(ErrorCodes.UnsupportedMediaTypeHeader);
                            errorLocation = exception.Message;
                        
                        var errorDetails = new ErrorDetails()
                        {
                            Location = errorLocation,
                            Code = currentErrorCatalog.Code,
                            Problem = currentErrorCatalog.Problem,
                            Action = currentErrorCatalog.Action
                        };
                        res.Errors.Add(errorDetails);
                        return (res, currentErrorCatalog.HttpResponseCode);
                    }
                default:
                    {
                        var currentErrorCatalog = errorsInformation.GetErrorCatalogByCode(ErrorCodes.UnrecoverableTechnicalIssue);
                        var errorDetails = new ErrorDetails()
                        {
                            Location = "Service",
                            Code = currentErrorCatalog.Code,
                            Problem = currentErrorCatalog.Problem,
                            Action = currentErrorCatalog.Action
                        };
                        res.Errors.Add(errorDetails);
                        return (res, currentErrorCatalog.HttpResponseCode);
                    }
            }

        }
    }
}
