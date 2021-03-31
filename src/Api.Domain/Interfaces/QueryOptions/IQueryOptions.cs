using Api.Domain.swagger;
using Domain.Interfaces.QueryOptions;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Api.Domain.Interfaces.QueryOptions
{
    public interface IQueryOptions
    {
        IPagination Pagination { get; set; }
        IQuery Query { get; set; }
        IOrderBy OrderBy { get; set; }
        bool IsQuery();

        
        [SwaggerIgnore]
        IEnumerable<object> Rows { get; set; }
        [SwaggerIgnore]
        int Count { get; set; }

        void setRows(IEnumerable<object> Rows);

    }
}
