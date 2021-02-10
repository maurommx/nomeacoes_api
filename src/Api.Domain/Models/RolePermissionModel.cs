
using System.Collections.Generic;

namespace Api.Domain.Models
{
    public class RolePermissionModel : BaseModel
    {

        private IEnumerable<PermissionModel> _permission;
        public IEnumerable<PermissionModel> Permissions
        {
            get { return _permission; }
            set { _permission = value; }
        }

        private IEnumerable<RoleModel> _role;
        public IEnumerable<RoleModel> Roles
        {
            get { return _role; }
            set { _role = value; }
        }


    }
}
