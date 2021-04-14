using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Engine.Constants
{
    public class ErrorCodes
    {
        /// <summary>
        /// An error that might be recoverable if the operation is retried
        /// </summary>
        public const int RecoverableTechnicalIssue = 310;
        /// <summary>
        /// An unrecoverable error that needs a support call
        /// </summary>
        public const int UnrecoverableTechnicalIssue = 320;
        /// <summary>
        /// Auth service unavailable
        /// </summary>
        public const int AuthServiceUnavailable = 330;
        /// <summary>
        /// Auth header is missing
        /// </summary>
        public const int HeaderNotProvided = 430;
        /// <summary>
        /// Auth token is not valid
        /// </summary>
        public const int TokenIsInvalid = 440;

        public const int PublishUsageEventFailed = 450;

        public const int ValidationFailed = 460;
        public const int UnsupportedMediaTypeHeader = 470;
        public const int UnsupportedMediaTypeBody = 480;

        public const int MissingOrMalformedRequiredHeader = 490;

        public const int IncidentErrorCodesStartRange = 300;
        public const int IncidentErrorCodesEndRange = 400;
    }
}
