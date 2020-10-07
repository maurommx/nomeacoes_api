using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace Api.Domain.Entities
{
    public class ElectionEntity : BaseEntity // Eleição
    {
        [Required]
        [MaxLength(30)]
        public string Name { get; set; }
        public virtual IEnumerable<OfficeEntity> Offices { get; set; } //Cargos
    }
}
