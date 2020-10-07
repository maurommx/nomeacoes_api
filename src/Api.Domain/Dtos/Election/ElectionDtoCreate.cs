using System;
using System.ComponentModel.DataAnnotations;

namespace Api.Domain.Dtos.Election
{
    public class ElectionDtoCreate
    {
        [Required(ErrorMessage = "Nome é um campo obrigatório")]
        [StringLength(60, ErrorMessage = "Nome deve ter no máximo {1} caracteres.")]
        public string Name { get; set; }
    }
}
