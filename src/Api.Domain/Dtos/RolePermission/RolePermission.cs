using System;

namespace Api.Domain.Dtos.RolePermissions
{
    public class RolePermissionsDto
    {
        public Guid Id { get; set; }
        public Guid PermissionId { get; set; }
        public Guid RoleId { get; set; }
        public DateTime CreateAt { get; set; }
        public DateTime UpdateAt { get; set; }
    }
}
