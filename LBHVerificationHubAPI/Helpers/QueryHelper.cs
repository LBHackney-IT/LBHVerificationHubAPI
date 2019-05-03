using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ClearCoreService;
using LBHVerificationHubAPI.Models;
using LBHVerificationHubAPI.UseCases.V1.Search.Models;
using LBHVerificationHubAPI.Helpers;
using System.Reflection;

namespace LBHVerificationHubAPI.Helpers
{
    public class QueryHelper
    {
        public static ScvQueryDef CreateQueryDefinition(ParkingPermitVerificationRequest request)
        {
            SCVField[][] records = ConvertRequestToFieldArray(request);
            ScvQueryDef query = new ScvQueryDef()
            {
                DatamapName = GlobalConstants.CLEARCORE_DATAMAP_NAME,
                FeedName = GlobalConstants.CLEARCORE_FEED_NAME,
                MatchRulesetName = GlobalConstants.CLEARCORE_MATCH_RULESET_NAME,
                ProjectName = GlobalConstants.CLEARCORE_PROJECT_NAME,
                Records = records
            };

            return query;
        }

        private static SCVField[][] ConvertRequestToFieldArray(ParkingPermitVerificationRequest request)
        {
            //Uses custom attributes on the Request object to get the ClearCore field name for the properties in ClearCore.

            List<SearchField> searchFields = new List<SearchField>();
            
            foreach (PropertyInfo propertyInfo in request.GetType().GetProperties())
            {
                if (propertyInfo.GetValue(request, null) != null)
                {
                    string propertyName = propertyInfo.Name;

                    object[] attribute = propertyInfo.GetCustomAttributes(typeof(ClearCoreProperty), true);
                    // Just in case you have a property without this annotation
                    if (attribute.Length > 0)
                    {
                        ClearCoreProperty myAttribute = (ClearCoreProperty)attribute[0];
                        string propertyValue = myAttribute.AlternativeFieldName;
                        searchFields.Add(new SearchField { Name = propertyValue, Value = propertyInfo.GetValue(request, null).ToString() });
                    }                    
                }
            }
            SCVField[][] records = new SCVField[][] { searchFields.Select(term => new SCVField() { Name = term.Name, Value = term.Value }).ToArray() };
            return records;
        }

        public static ClearCoreResponse CreateResponse(ScvQueryResult results)
        {
            ClearCoreResponse response = new ClearCoreResponse();
            bool verified = false;
            //Do stuff here to generate a response object from the returned ClearCore results.
            if(results.Usns.Count() > 0)//at least 1 USN has been returned so we're valid???? This may need to be developed further
            {
                verified = true;
                response.VerificationAuditID = SaveAuditDetails(results.m_matchAudits);
            }
            else
            {
                verified = false;
                response.VerificationAuditID = string.Empty;
            }
            response.verified = verified;

            return response;
        }

        private static string SaveAuditDetails(string[] m_matchAudits)
        {
            //TODO: Save the audit details in to database and return the ID
            //use SCVXlateMatchAudit to get the better description of the audit
            //store it in the database and retrieve the ID

            return Guid.NewGuid().ToString();
        }
    }
}
