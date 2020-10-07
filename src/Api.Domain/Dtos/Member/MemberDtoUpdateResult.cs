using System;

namespace Api.Domain.Dtos.Member
{
    public class MemberDtoUpdateResult
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public DateTime UpdateAt { get; set; }
    }
}
