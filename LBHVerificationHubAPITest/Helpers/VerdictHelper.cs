using System;
using System.Collections.Generic;
using Bogus;
using LBHVerificationHubAPI.Domain;
using LBHVerificationHubAPI.UseCases.V1.Search.Models;

namespace LBHVerificationHubAPITest.Helpers
{
    public static class VerdictHelper
    {
        public static Verdict RandomVerdict()
        {
            var person = new Person("en_GB");
            var permitRequest = new ParkingPermitVerificationRequest
            {
                Surname = person.LastName,
                ForeName = person.FirstName,
                EmailAddress = person.Email,
                TelephoneNumber = person.Phone,
                DOB = person.DateOfBirth.ToString(),
                UPRN = "1000" + new Random().Next(10000000, 99999999),
            };

            return new Verdict
            {
                GeneratedAt = DateTime.Now,
                Uprn = permitRequest.UPRN,
                Verified = Convert.ToBoolean(new Random().Next(2)),
                VerdictId = Guid.NewGuid(),
                Request = permitRequest,
                LateMatchAudits = new List<string> {"FOR TESTING"}
            };
        }
    }
}