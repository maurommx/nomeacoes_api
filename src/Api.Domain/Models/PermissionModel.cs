
using System.Collections.Generic;

namespace Api.Domain.Models
{
    public class PermissionModel : BaseModel
    {
        private string _name;
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        private string _slug;
        public string Slug
        {
            get { return _slug; }
            set { _slug = value; }
        }

    }
}
