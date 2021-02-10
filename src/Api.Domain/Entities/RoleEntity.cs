using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Api.Domain.Entities
{
    public class RoleEntity : BaseEntity
    {

        [Required]
        [MaxLength(30)]
        public string Name { get; set; }
        [Required]
        public virtual IEnumerable<RolePermissionEntity> RolePermissions { get; set; }

    }
}
