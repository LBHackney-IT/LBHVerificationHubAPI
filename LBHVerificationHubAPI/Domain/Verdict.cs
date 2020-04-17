using System;
using System.Collections.Generic;
using LBHVerificationHubAPI.UseCases.V1.Search.Models;

namespace LBHVerificationHubAPI.Domain
{
    public class Verdict
    {
        /// <summary>
        /// The approximate time the verdict Write request was made.
        /// </summary>
        public DateTime GeneratedAt;
        
        /// <summary>
        /// The Unique Property Reference Number for which the verification request was made.
        /// </summary>
        public string Uprn;
        
        /// <summary>
        /// Whether the information provided in the verification request was verified or not.
        /// </summary>
        public bool Verified;
        
        /// <summary>
        /// The unique ID of the Verdict, to be queried against on the database.
        /// Is required where Verified == true.
        /// </summary>
        public Guid VerdictId;

        /// <summary>
        /// The original request body.
        /// </summary>
        public ParkingPermitVerificationRequest Request;

        /// <summary>
        /// The (more) human-readable description of a late match audit for the validation.
        /// </summary>
        public List<string> LateMatchAudit;
    }
}