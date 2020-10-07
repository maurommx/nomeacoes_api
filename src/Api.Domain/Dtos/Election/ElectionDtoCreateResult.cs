using System;

namespace Api.Domain.Dtos.Election
{
    public class ElectionDtoCreateResult
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public DateTime CreateAt { get; set; }
    }
}
