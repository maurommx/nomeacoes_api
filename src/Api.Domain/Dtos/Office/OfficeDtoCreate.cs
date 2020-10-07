using System;
using System.ComponentModel.DataAnnotations;

namespace Api.Domain.Dtos.Office
{
    public class OfficeDtoCreate
    {
        [Required(ErrorMessage = "Nome é um campo obrigatório")]
        [StringLength(50, ErrorMessage = "Nome deve ter no máximo {1} caracteres.")]
        public string Name { get; set; }
        public Guid ElectionId { get; set; }
        [Range(0, int.MaxValue, ErrorMessage = "Quantidade de Associados inválido")]
        public int QtdeAssociates { get; set; }
        public DateTime CreateAt { get; set; }
    }
}
