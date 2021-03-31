using System.Collections.Generic;
using System.Threading.Tasks;
using Api.Domain.Interfaces.QueryOptions;
using Domain.Interfaces.QueryOptions;
using Domain.QueryOptions;
using System.Text.Json.Serialization;
using Api.Domain.swagger;

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

        private IQuery query;

        public IQuery Query
        {
            get { return query; }
            set { query = value; }
        }


        private IOrderBy orderBy;   
        public IOrderBy OrderBy
        {
            get { return orderBy; }
            set { orderBy = value; }
        }
        

        private IEnumerable<object> rows;
        [SwaggerIgnore]
        public IEnumerable<object> Rows
        {
            get { return rows; }
            set { rows = value; }
        }

        private int count;
        [SwaggerIgnore]
        public int Count
        {
            get { return count; }
            set { count = value; }
        }


        public bool IsQuery()
        {
            if (Query == null)
                return false;
            if ((!string.IsNullOrEmpty(Query.Field)) && (!string.IsNullOrEmpty(Query.Text)))
                return true;
            else
                return false;
        }

        public void setRows(IEnumerable<object> Rows)
        {
            this.rows = Rows;
        }


        public QueryOptions()
        {
            pagination = new Pagination();
            query = new Query();
            orderBy = new OrderBy();
            rows = null;
            count = 0;
        }


        public QueryOptions(IPagination Pagination)
        {
            pagination = Pagination;
        }

        public QueryOptions(IPagination Pagination, IQuery Query) : this(Pagination) {
            query = Query;
        }

        public QueryOptions(IPagination Pagination, IQuery Query, IOrderBy OrderBy) : this(Pagination, Query)
        {
            orderBy = OrderBy;
        }

    }
}
