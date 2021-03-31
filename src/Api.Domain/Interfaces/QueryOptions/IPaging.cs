namespace Api.Domain.Interfaces.QueryOptions
{
    public interface IPaging
    {
        int Page { get; set; }
        int PageSize { get; set; }
        int PageCount { get; }
        int Records { get; set; }
    }
}
