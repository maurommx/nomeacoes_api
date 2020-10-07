using System;
using System.ComponentModel.DataAnnotations;

namespace Api.Domain.Entities
{
    public class ElectedEntity : BaseEntity //Eleito
    {
        public Guid OfficeId { get; set; }
        public virtual OfficeEntity Office { get; set; }
        public Guid MemberId { get; set; }
        public virtual MemberEntity Member { get; set; }
        public bool Active { get; set; }
        public int Wishes { get; set; }  // Quantidade de votos
    }
}
