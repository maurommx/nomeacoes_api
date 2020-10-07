using System;
using Api.Domain.Dtos.Member;
using Api.Domain.Dtos.Office;

namespace Api.Domain.Dtos.Associate
{
    public class AssociateDtoUpdateResult
    {
        public Guid Id { get; set; }
        public OfficeDto Office { get; set; }
        public Guid OfficeId { get; set; }
        public MemberDto Member { get; set; }
        public Guid MemberId { get; set; }
        public bool Active { get; set; }
        public int Wishes { get; set; }
        public DateTime UpdateAt { get; set; }
    }
}
