using LBHVerificationHubAPI.Extensions.Controller;
using LBHVerificationHubAPI.Infrastructure.V1.UseCase.Execution;
using Microsoft.AspNetCore.Mvc;

namespace LBHVerificationHubAPI.Controllers.V1
{
    public class BaseController : Controller
    {
        public IActionResult HandleResponse<T>(IExecuteWrapper<T> result) where T : class
        {
            return this.ExecuteStandardResponse(result);
        }

        public IActionResult HandleResponse<T>(T result) where T : class
        {
            return this.StandardResponse(result);
        }
    }
}
