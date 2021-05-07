using Api.Domain.Interfaces.QueryOptions;

namespace Domain.Interfaces.QueryOptions
{
    public interface IQueryOptionsInput
    {
        public interface IQueryOptionsInput
        {
            IPaginationInput Paging { get; set; }
            IQueryInput Query { get; set; }
            IOrderBy OrderBy { get; set; }
        }
    }
}
