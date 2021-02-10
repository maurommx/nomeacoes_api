
using System.Collections.Generic;

namespace Api.Domain.Models
{
    public class RoleModel : BaseModel
    {
        private string _name;
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

    }
}
