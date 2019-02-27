using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LBHVerificationHubAPI.Interfaces
{
    public interface ILoggerAdapter<T>
    {
        void LogInformation(string message);
        void LogError(string message, params object[] args);
    }
}
