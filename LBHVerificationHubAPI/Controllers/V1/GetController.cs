using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using LBHVerificationHubAPI.UseCases.V1.Objects;
using LBHVerificationHubAPI.Models;
using LBHVerificationHubAPI.Infrastructure.V1.API;
using LBHVerificationHubAPI.Extensions.Controller;
using LBHVerificationHubAPI.UseCases.V1.Search.Models;

namespace LBHVerificationHubAPI.Controllers.V1
{
    [ApiVersion("1")]
    [Produces("application/json")]
    [Route("api/v1/path")]
    [ProducesResponseType(typeof(APIResponse<object>), 400)]
    [ProducesResponseType(typeof(APIResponse<object>), 500)]
    public class GetController : BaseController
    {
        private readonly IGetUseCase _getUseCase;

        public GetController(IGetUseCase UseCase)
        {
            _getUseCase = UseCase;
        }

        /// <summary>
        /// Returns an  from the given 
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        [HttpGet, MapToApiVersion("1")]
        [Route("{ID}")]
        [ProducesResponseType(typeof(APIResponse<SearchResponse>), 200)]
        public async Task<IActionResult> Get(string ID)
        {
            GetRequest request = new GetRequest { ID = ID };
            var response = await _getUseCase.ExecuteAsync(request, HttpContext.GetCancellationToken()).ConfigureAwait(false);

            return HandleResponse(response);
        }



    }
}