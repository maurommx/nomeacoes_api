using Domain.Interfaces.QueryOptions;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.QueryOptions
{
    public class OrderBy : IOrderBy
    {
		private string field;

		public string Field
		{
			get { return field; }
			set { field = value; }
		}

		private string direction = "";

		public string Direction
		{
			get { return direction; }
			set { direction = value; }
		}

		public OrderBy()
		{
		}

		public OrderBy(string Field)
		{
			field = Field;
		}

		public OrderBy(string Field, string Direction) : this(Field)
		{
			direction = Direction;
		}

        public string GetOrderString()
        {
			string ord = "";
			ord = (string.IsNullOrWhiteSpace(field)) ? "" : field;
			ord += (string.IsNullOrEmpty(ord)) ? "" : " " + direction;
            return ord;
        }
		
    }
}
