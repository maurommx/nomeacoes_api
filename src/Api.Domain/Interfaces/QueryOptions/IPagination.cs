namespace Api.Domain.Interfaces.QueryOptions
{
    public interface IPagination
    {
        int Page { get; set; }
        int PageSize { get; set; }
        int PageCount { get; }
        int Records { get; set; }
    }
}
