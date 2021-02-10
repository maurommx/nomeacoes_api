using System;
using System.ComponentModel.DataAnnotations;

namespace Api.Domain.Entities
{
    public class UserEntity : BaseEntity
    {

        [Required]
        [MaxLength(60)]
        public string Name { get; set; }
        [Required]
        [MaxLength(100)]
        public string Email { get; set; }
        [MaxLength(50)]
        public string Senha { get; set; }
        public Guid RoleId { get; set; }
        public virtual RoleEntity Role { get; set; }

    }
}
