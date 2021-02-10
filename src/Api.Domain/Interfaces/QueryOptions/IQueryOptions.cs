using System.Collections.Generic;
using System.Threading.Tasks;

namespace Api.Domain.Interfaces.QueryOptions
{
    public interface IQueryOptions
    {
        IPagination Pagination { get; set; }
        dynamic Rows { get; set; }

    }
}
