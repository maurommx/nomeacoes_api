namespace Api.Domain.Interfaces.QueryOptions
{
    public interface IPaginationInput
    {
        int Page { get; set; }
        int PageSize { get; set; }
    }
}