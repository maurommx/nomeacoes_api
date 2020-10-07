using System;

namespace Api.Domain.Models
{
    public class ElectedModel : BaseModel
    {
        private Guid _officeId;
        public Guid OfficeId
        {
            get { return _officeId; }
            set { _officeId = value; }
        }

        private Guid _memberId;
        public Guid MemberId
        {
            get { return _memberId; }
            set { _memberId = value; }
        }

        private bool _active;
        public bool Active
        {
            get { return _active; }
            set { _active = value; }
        }

        private int _wishes;
        public int Wishes
        {
            get { return _wishes; }
            set { _wishes = value; }
        }



    }
}
