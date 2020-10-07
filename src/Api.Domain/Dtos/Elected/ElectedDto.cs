using System;
using Api.Domain.Dtos.Member;
using Api.Domain.Dtos.Office;

namespace Api.Domain.Dtos.Elected
{
    public class ElectedDto
    {
        public Guid Id { get; set; }
        public OfficeDto Office { get; set; }
        public Guid OfficeId { get; set; }
        public MemberDto Member { get; set; }
        public Guid MemberId { get; set; }
        public bool Active { get; set; }
        public int Wishes { get; set; }
        public DateTime CreateAt { get; set; }
    }
}
