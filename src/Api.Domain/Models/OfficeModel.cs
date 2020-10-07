using System;

namespace Api.Domain.Models
{
    public class OfficeModel : BaseModel
    {
        private string _name;
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        private int _qtdeAssociates;
        public int QtdeAssociates
        {
            get { return _qtdeAssociates; }
            set { _qtdeAssociates = value; }
        }


    }
}
