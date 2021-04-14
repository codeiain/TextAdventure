using System.Collections.Generic;
using System.Linq;
using Engine.Constants;

namespace Engine.Exceptions
{
    public class FriendlyErrorResponseFactory
    {
        private readonly ErrorsInformation errorsInformation;
        public FriendlyErrorResponseFactory(ErrorsInformation errorsInformation)
        {
            this.errorsInformation = errorsInformation;
        }


        public ErrorSummary GetFriendlyResponse(List<KeyValuePair<string, int>> validationErrors, string response)
        {
            var res = new ErrorSummary();
            var errorsDetails = validationErrors.Select(x =>
            {
                var currentErrorCatalog = errorsInformation.GetErrorCatalogByCode(x.Value);
                var errorDetails = new ErrorDetails()
                {
                    Location = x.Key,
                    Code = x.Value,
                    Problem = currentErrorCatalog.Problem,
                    Action = currentErrorCatalog.Action
                };
                return errorDetails;
            }).ToList();
            res.Errors = errorsDetails;
            //res.CorrelationId = currentRequestData.CorrelationId.ToString();
            res.Response = response;
            return res;
        }
    }
}