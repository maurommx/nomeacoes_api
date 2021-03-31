using Api.Domain.Interfaces.QueryOptions;

namespace Domain.Interfaces.QueryOptions
{
    public interface IQueryOptionsInput
    {
        public interface IQueryOptionsInput
        {
            IPaging Paging { get; set; }
            IQuery Query { get; set; }
            IOrderBy OrderBy { get; set; }
        }
    }
}
