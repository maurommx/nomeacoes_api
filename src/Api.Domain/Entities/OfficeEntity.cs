using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Api.Domain.Entities
{
    public class OfficeEntity : BaseEntity  // Cargo
    {
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }
        public Guid ElectionId { get; set; }
        public virtual ElectionEntity Election { get; set; }
        public virtual IEnumerable<ElectedEntity> Electeds { get; set; }  // Associados
        // public ElectedEntity Elected { get; set; }  // Eleito para o Cargo
        public int QtdeAssociates { get; set; } // Quantidade de Associados
        public virtual IEnumerable<AssociateEntity> Associates { get; set; }  // Associados
    }
}
