using System.Collections.Generic;
using System.Linq;
using System.Net;

namespace Engine.Constants
{
    public class ErrorsInformation
    {
        public ErrorsInformation()
        {
            Catalogs = new List<ErrorCatalog>();
            Catalogs.Add(new ErrorCatalog()
            {
                Code = ErrorCodes.RecoverableTechnicalIssue,
                Problem = "Could not communicate with some internal dependencies",
                Action = "Try again in few seconds or contact the support team"
            });

            Catalogs.Add(new ErrorCatalog()
            {
                Code = ErrorCodes.HeaderNotProvided,
                Problem = "Header was missing",
                Action = "Possible misspelling in header name."
            });

            Catalogs.Add(new ErrorCatalog()
            {
                Code = ErrorCodes.UnrecoverableTechnicalIssue,
                Problem = "There was an internal issue that was not recoverable",
                Action = "Please contact the helpdesk and provide error code along with correlation-id"
            });

            Catalogs.Add(new ErrorCatalog()
            {
                Code = ErrorCodes.TokenIsInvalid,
                Problem = "The passed token is invalid",
                Action = "Please pass a valid token"
            });

            Catalogs.Add(new ErrorCatalog()
            {
                Code = ErrorCodes.MissingOrMalformedRequiredHeader,
                Problem = "Missing or malformed header values",
                Action = "Please verify the required header values are present and valid",
                HttpResponseCode = (int)HttpStatusCode.BadRequest
            });

            Catalogs.Add(new ErrorCatalog()
            {
                Code = ErrorCodes.ValidationFailed,
                Problem = "Validation Failed",
                Action = "Please resolve the above validation issues",
                HttpResponseCode = (int)HttpStatusCode.BadRequest
            });

            Catalogs.Add(new ErrorCatalog()
            {
                Code = ErrorCodes.UnsupportedMediaTypeHeader,
                Problem = "Unsupported media type",
                Action = "Please be sure that Content-Type header value is application/xml",
                HttpResponseCode = (int)HttpStatusCode.UnsupportedMediaType
            });

            Catalogs.Add(new ErrorCatalog()
            {
                Code = ErrorCodes.UnsupportedMediaTypeBody,
                Problem = "Unsupported media type",
                Action = "Please be sure that your request body is valid XML",
                HttpResponseCode = (int)HttpStatusCode.UnsupportedMediaType
            });

            Catalogs.Add(new ErrorCatalog()
            {
                Code = ErrorCodes.AuthServiceUnavailable,
                Problem = "Could not contact Authorization Service",
                Action = "Could not verify credentials at this time. Please try again shortly",
                HttpResponseCode = (int)HttpStatusCode.Forbidden
            });
        }
        public List<ErrorCatalog> Catalogs { get; private set; }

        public ErrorCatalog GetErrorCatalogByCode(int code)
        {
            return Catalogs.FirstOrDefault(x => x.Code == code);
        }
    }
}