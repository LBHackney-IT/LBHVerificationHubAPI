using LBHVerificationHubAPI.Infrastructure.V1.API;

namespace LBHVerificationHubAPI.Infrastructure.V1.UseCase.Execution
{
    public interface IExecuteWrapper<T>
    {
        bool IsSuccess { get; set; }
        T Result { get; set; }
        APIError Error { get; set; }
    }
}
