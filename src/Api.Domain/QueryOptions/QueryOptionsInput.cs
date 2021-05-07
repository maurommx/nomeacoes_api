using System.Collections.Generic;
using System.Threading.Tasks;
using Api.Domain.Interfaces.QueryOptions;
using Domain.Interfaces.QueryOptions;
using Domain.QueryOptions;
using System.Text.Json.Serialization;
using Api.Domain.swagger;

namespace Api.Domain.QueryOptions
{
    public class QueryOptionsInput : IQueryOptionsInput
    {
        private IPaginationInput pagination;
        public IPaginationInput Pagination
        {
            get { return pagination; }
            set { pagination = value; }
        }

        private IQueryInput query;

        public IQueryInput Query
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
        





        public QueryOptionsInput()
        {
            pagination = new PaginationInput();
            query = new QueryInput();
            orderBy = new OrderBy();
        }


        public QueryOptionsInput(IPaginationInput Pagination)
        {
            pagination = Pagination;
        }

        public QueryOptionsInput(IPaginationInput Pagination, IQueryInput Query) : this(Pagination) {
            query = Query;
        }

        public QueryOptionsInput(IPaginationInput Pagination, IQueryInput Query, IOrderBy OrderBy) : this(Pagination, Query)
        {
            orderBy = OrderBy;
        }

    }
}
