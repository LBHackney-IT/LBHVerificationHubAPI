namespace LBHVerificationHubAPI.Infrastructure.V1.API
{
    public interface IPagedRequest
    {
        int Page { get; set; }
        int PageSize { get; set; }
    }
}