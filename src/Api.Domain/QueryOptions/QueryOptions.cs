using System.Collections.Generic;
using System.Threading.Tasks;
using Api.Domain.Interfaces.QueryOptions;

namespace Api.Domain.QueryOptions
{
    public class QueryOptions : IQueryOptions
    {
        private IPagination pagination;
        public IPagination Pagination
        {
            get { return pagination; }
            set { pagination = value; }
        }

        private dynamic rows;
        public dynamic Rows
        {
            get { return rows; }
            set { rows = value; }
        }


        public QueryOptions()
        {
            pagination = new Pagination();
        }

        public QueryOptions(IPagination Pagination)
        {
            pagination = Pagination;
        }

    }
}
