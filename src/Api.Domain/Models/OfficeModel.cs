using System;

namespace Api.Domain.Models
{
    public class OfficeModel : BaseModel
    {
        private Guid _electionId;
        public Guid ElectionId
        {
            get { return _electionId; }
            set { _electionId = value; }
        }


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
