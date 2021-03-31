using System;
using Api.Domain.Interfaces.QueryOptions;

namespace Api.Domain.QueryOptions
{
    public class SortBy : ISortBy
    {
        private string field = "";
        public string Field
        {
            get { return field; }
            set { field = value; }
        }

        private bool desc = false;
        public bool Desc
        {
            get { return desc; }
            set { desc = value; }
        }

        

        public SortBy()
        {
        }

        public SortBy(string Field) 
        {
            field = Field;
        }

        public SortBy(string Field, bool Desc) : this(Field)
        {
            desc = Desc;
        }

    }
}
