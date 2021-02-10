using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Api.Domain.Entities
{
    public class PermissionEntity : BaseEntity
    {

        [Required]
        [MaxLength(30)]
        public string Name { get; set; }
        [Required]
        [MaxLength(50)]
        public string Slug { get; set; }
        public virtual IEnumerable<RolePermissionEntity> RolePermissions { get; set; }

    }
}
