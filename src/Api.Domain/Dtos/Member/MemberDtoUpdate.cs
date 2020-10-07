using System.ComponentModel.DataAnnotations;

namespace Api.Domain.Dtos.Member
{
    public class MemberDtoUpdate
    {
        [Required(ErrorMessage = "Nome é um campo obrigatório")]
        [StringLength(50, ErrorMessage = "Nome deve ter no máximo {1} caracteres.")]
        public string Name { get; set; }
    }
}
