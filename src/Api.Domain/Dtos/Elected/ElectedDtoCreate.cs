using System;
using System.ComponentModel.DataAnnotations;

namespace Api.Domain.Dtos.Elected
{
    public class ElectedDtoCreate
    {
        [Required(ErrorMessage = "OfficeId é um campo obrigatório")]
        public Guid OfficeId { get; set; }

        [Required(ErrorMessage = "MemberId é um campo obrigatório")]
        public Guid MemberId { get; set; }
        public bool Active { get; set; }
        public int Wishes { get; set; }
    }
}
