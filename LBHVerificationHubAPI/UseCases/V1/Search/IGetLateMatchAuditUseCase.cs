using System.Collections.Generic;
using System.Threading.Tasks;

namespace LBHVerificationHubAPI.UseCases.V1.Search
{
    public interface IGetLateMatchAuditsUseCase
    {
        /// <summary>
        /// Returns more descriptive and human-readable representations of the Match Audits
        /// returned by default by ClearCore.
        /// </summary>
        /// <param name="matchAudits">List of match audits returned by ClearCore.</param>
        /// <returns>List<String> of Late Match Audits</returns>
        Task<List<string>> ExecuteAsync(List<string> matchAudits);
    }
}