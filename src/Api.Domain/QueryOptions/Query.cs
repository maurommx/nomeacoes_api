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

		private OperatorsEnum _operator = OperatorsEnum.CONTEM;

		public OperatorsEnum Operator
		{
			get { return _operator; }
			set { _operator = value; }
		}

        public string GetQueryString()
        {
            string ret = null;
            switch (Operator)
            {
                case OperatorsEnum.IGUAL:
                    ret = $"{Field} = '{Text}'";
                    break;
                case OperatorsEnum.DIFERENTE:
                    ret = $"{Field} <> '{Text}'";
                    break;
                case OperatorsEnum.COMECACOM:
                    ret = $"{Field} LIKE '{Text}%'";
                    break;
                case OperatorsEnum.TERMINACOM:
                    ret = $"{Field} LIKE '%{Text}'";
                    break;
                case OperatorsEnum.CONTEM:
                    ret = $"{Field} LIKE \"%{Text}%\"";
                    break;
                case OperatorsEnum.MAIOR:
                    ret = $"{Field} > {Text}";
                    break;
                case OperatorsEnum.MAIOROUIQUAL:
                    ret = $"{Field} >= {Text}";
                    break;
                case OperatorsEnum.MENOR:
                    ret = $"{Field} < {Text}";
                    break;
                case OperatorsEnum.MENOROUIGUAL:
                    ret = $"{Field} <= {Text}";
                    break;
            }
            return ret;
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

        public Query(string Field, string Text, OperatorsEnum Operator) : this(Field, Text)
        {
            this._operator = Operator;
        }

    }
}
