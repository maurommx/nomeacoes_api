using System;
using Api.Domain.Interfaces.QueryOptions;

namespace Api.Domain.QueryOptions
{
    public class Pagination : IPagination
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

        public int PageCount => Convert.ToInt16(Math.Ceiling(Convert.ToDecimal(records) / Convert.ToDecimal(pageSize)));






        private int records;
        public int Records
        {
            get { return records; }
            set { records = value; }
        }

        public Pagination()
        {
            // page = 1;
            // pageSize = 10;
        }

        public Pagination(int Page)
        {
            page = Page;
        }
        public Pagination(int Page, int PageSize) : this(Page)
        {
            pageSize = PageSize;
        }

    }
}
