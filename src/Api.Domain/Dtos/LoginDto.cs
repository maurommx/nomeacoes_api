using System.ComponentModel.DataAnnotations;

namespace Api.Domain.Dtos
{
    public class LoginDto
    {
        [Required(ErrorMessage = "Email é um campo obrigatório para Login")]
        [EmailAddress(ErrorMessage = "E-mail em formato inválido.")]
        [StringLength(100, ErrorMessage = "Email deve ter no máximo {1} caracteres.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Senha é um campo obrigatório para Login")]
        [StringLength(50, ErrorMessage = "Senha deve ter no máximo {1} caracteres.")]
        public string Senha { get; set; }


    }
}
