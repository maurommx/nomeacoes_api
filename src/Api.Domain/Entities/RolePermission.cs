using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Api.Domain.Entities
{
    public class RolePermissionEntity : BaseEntity
    {

        public Guid PermissionId { get; set; }
        public Guid RoleId { get; set; }
        public virtual PermissionEntity Permission { get; set; }
        public virtual RoleEntity Role { get; set; }

    }
}
