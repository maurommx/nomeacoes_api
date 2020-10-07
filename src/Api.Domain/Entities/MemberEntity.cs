using System.ComponentModel.DataAnnotations;

namespace Api.Domain.Entities
{
    public class MemberEntity : BaseEntity // Membro
    {
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }
        public byte[] Picture { get; set; }
    }
}
