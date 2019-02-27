using LBHVerificationHubAPI.Infrastructure.V1.API;
using LBHVerificationHubAPI.Infrastructure.V1.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LBHVerificationHubAPI.UseCases.V1.Search.Models
{
    public class GetRequest : IRequest
    {
        /// <summary>
        /// Exact match
        /// </summary>
        public string ID { get; set; }
        /// <summary>
        /// Responsible for validating itself.
        /// Uses SearchRequestValidator to do complex validation
        /// Sets defaults for Page and PageSize
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="request"></param>
        /// <returns>RequestValidationResponse</returns>
        public RequestValidationResponse Validate<T>(T request)
        {
            if (request == null)
                return new RequestValidationResponse(false, "request is null");
            var validator = new GetRequestValidator();
            var castedRequest = request as GetRequest;
            if (castedRequest == null)
                return new RequestValidationResponse(false);
            var validationResult = validator.Validate(castedRequest);

            return new RequestValidationResponse(validationResult);
        }
    }
}
