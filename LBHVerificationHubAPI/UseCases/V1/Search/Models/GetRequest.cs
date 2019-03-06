using LBHVerificationHubAPI.Infrastructure.V1.API;
using LBHVerificationHubAPI.Infrastructure.V1.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LBHVerificationHubAPI.UseCases.V1.Search.Models
{
    public class ParkingPermitVerificationCreateRequest : IRequest
    {
        public string ForeName { get; set; }

        public string Surname { get; set; }

        public string UPRN { get; set; }

        public string DOB { get; set; }

        public string EmailAddress { get; set; }

        public string TelephoneNumber { get; set; }


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
            var validator = new ParkingPermitVerificationRequestRequestValidator();
            var castedRequest = request as ParkingPermitVerificationCreateRequest;
            if (castedRequest == null)
                return new RequestValidationResponse(false);
            var validationResult = validator.Validate(castedRequest);

            return new RequestValidationResponse(validationResult);
        }
    }
}
