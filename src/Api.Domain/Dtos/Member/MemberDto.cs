using System;

namespace Api.Domain.Dtos.Member
{
    public class MemberDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public DateTime CreateAt { get; set; }
    }
}
