namespace LBHVerificationHubAPI.Infrastructure.V1.API
{
    public interface IPagedResponse
    {
        int PageCount { get; set; }
        int TotalCount { get; set; }
    }
}