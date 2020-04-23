using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace Com.Danliris.Service.Merchandiser.Lib.Ultilities
{
    [Serializable]
    internal class ServiceValidationException : Exception
    {
        private ValidationContext validationContext;
        private List<ValidationResult> validationResults;

        public ServiceValidationException()
        {
        }

        public ServiceValidationException(string message) : base(message)
        {
        }

        public ServiceValidationException(ValidationContext validationContext, List<ValidationResult> validationResults)
        {
            this.validationContext = validationContext;
            this.validationResults = validationResults;
        }

        public ServiceValidationException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected ServiceValidationException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}