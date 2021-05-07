using System;
using Api.Domain.Interfaces.QueryOptions;

namespace Api.Domain.QueryOptions
{
    public class PaginationInput : IPaginationInput
    {
        private int page = 1;
        public int Page
        {
            get { return page; }
            set { page = value; }
        }

        private int pageSize = 10;
        public int PageSize
        {
            get { return pageSize; }
            set { pageSize = value; }
        }

        

        public PaginationInput()
        {
            // page = 1;
            // pageSize = 10;
        }

        public PaginationInput(int Page)
        {
            page = Page;
        }
        public PaginationInput(int Page, int PageSize) : this(Page)
        {
            pageSize = PageSize;
        }

    }
}
