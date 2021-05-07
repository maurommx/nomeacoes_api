using Domain.Interfaces.QueryOptions;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.QueryOptions
{
    public class Query : IQuery
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
            if (!String.IsNullOrEmpty(field)) {
                string ret = null;
                switch (Operator.ToUpper())
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
            } else {
                return null;
            }
        }

        public Query() { }

        public Query(string Field)
        {
            this.field = Field;
        }

        public Query(string Field, string Text) : this(Field)
        {
            this.text = Text;
        }

        public Query(string Field, string Text, string Operator) : this(Field, Text)
        {
            this._operator = Operator;
        }

    }
}
