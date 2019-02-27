using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LBHVerificationHubAPI.Infrastructure.V1.API
{
    public interface IPagedResults<T>
    {
        List<T> Results { get; set; }
        int TotalResultsCount { get; set; }
    }
}
