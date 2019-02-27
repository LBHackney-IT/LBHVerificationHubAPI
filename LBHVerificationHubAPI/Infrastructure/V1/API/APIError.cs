using System;
using System.Collections.Generic;
using LBHVerificationHubAPI.Infrastructure.V1.UseCase.Execution;
using LBHVerificationHubAPI.Infrastructure.V1.Validation;

namespace LBHVerificationHubAPI.Infrastructure.V1.API
{
    public class APIError
    {
        public bool IsValid { get; set; }
        public IList<ExecutionError> Errors { get; set; }
        public IList<ValidationError> ValidationErrors { get; set; }

        public APIError(RequestValidationResponse validationResponse)
        {
            if (validationResponse == null)
                IsValid = false;
            else
            {
                IsValid = validationResponse.IsValid;
                ValidationErrors = validationResponse.ValidationErrors;
            }
        }

        public APIError(Exception ex)
        {
            Errors = new List<ExecutionError> { new ExecutionError(ex) };
        }

        public APIError(ExecutionError error)
        {
            Errors = new List<ExecutionError> { error };
        }


    }
}
