using LBHVerificationHubAPI.Infrastructure.V1.API;
using LBHVerificationHubAPI.Infrastructure.V1.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LBHVerificationHubAPI.UseCases.V1.Search.Models
{
    public class ParkingPermitVerificationRequest : IRequest
    {
        
        [ClearCoreProperty(AlternativeFieldName = "FORENAME")]
        public string ForeName { get; set; }

        [ClearCoreProperty(AlternativeFieldName = "SURNAME")]
        public string Surname { get; set; }

        [ClearCoreProperty(AlternativeFieldName = "UPRN")]
        public string UPRN { get; set; }

        [ClearCoreProperty(AlternativeFieldName = "DOB")]
        public string DOB { get; set; }

        [ClearCoreProperty(AlternativeFieldName = "EMAIL")]
        public string EmailAddress { get; set; }

        [ClearCoreProperty(AlternativeFieldName = "TEL")]
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
            var castedRequest = request as ParkingPermitVerificationRequest;
            if (castedRequest == null)
                return new RequestValidationResponse(false);
            var validationResult = validator.Validate(castedRequest);

            return new RequestValidationResponse(validationResult);
        }
        
        public Dictionary<string, string> GetQueryDict()
        {
            var dict = new Dictionary<string, string>();
            foreach (var prop in this.GetType().GetProperties())
                if (prop.GetValue(this, null) != null)
                    dict.Add(prop.Name, prop.GetValue(this, null).ToString());

            return dict;
        }
    }

    public class ClearCoreProperty : Attribute
    {
        public string AlternativeFieldName { get; set; }
    }
}
