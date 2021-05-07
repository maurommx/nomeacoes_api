using Domain.Interfaces.QueryOptions;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.QueryOptions
{
    public class QueryInput : IQueryInput
    {
		private string field = "";

		public string Field
		{
			get { return field; }
			set { field = value; }
		}

		private string text = "";

		public string Text
		{
			get { return text; }
			set { text = value; }
		}

		private string _operator = "CONTEM";

		public string Operator
		{
			get { return _operator; }
			set { _operator = value; }
		}

        public string GetQueryString()
        {
            string ret = null;
            switch (Operator)
            {
                case "IGUAL":
                    ret = $"{Field} = '{Text}'";
                    break;
                case "DIFERENTE":
                    ret = $"{Field} <> '{Text}'";
                    break;
                case "COMECACOM":
                    ret = $"{Field} LIKE '{Text}%'";
                    break;
                case "TERMINACOM":
                    ret = $"{Field} LIKE '%{Text}'";
                    break;
                case "CONTEM":
                    ret = $"{Field}.Contains(\"%{Text}%\")";
                    // ret = $"{Field} LIKE \"%{Text}%\"";
                    break;
                case "MAIOR":
                    ret = $"{Field} > {Text}";
                    break;
                case "MAIOROUIQUAL":
                    ret = $"{Field} >= {Text}";
                    break;
                case "MENOR":
                    ret = $"{Field} < {Text}";
                    break;
                case "MENOROUIGUAL":
                    ret = $"{Field} <= {Text}";
                    break;
            }
            return ret;
        }

        public QueryInput() { }

        public QueryInput(string Field)
        {
            this.field = Field;
        }

        public QueryInput(string Field, string Text) : this(Field)
        {
            this.text = Text;
        }

        public QueryInput(string Field, string Text, string Operator) : this(Field, Text)
        {
            this._operator = Operator;
        }

    }
}
