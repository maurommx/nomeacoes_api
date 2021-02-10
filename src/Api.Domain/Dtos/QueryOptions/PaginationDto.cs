namespace Api.Domain.Dtos.QueryOptions
{
    public class PaginationDto
    {
        public int Page { get; set; }
        public int PageSize { get; set; }
        public int PageCount { get; set; }
        public int Records { get; set; }

    }
}
