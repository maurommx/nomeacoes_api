using System.Reflection.Metadata;

namespace Api.Domain.Models
{
    public class MemberModel : BaseModel
    {
        private string _name;
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        private byte[] _picture;
        public byte[] Picture
        {
            get { return _picture; }
            set { _picture = value; }
        }


    }
}
