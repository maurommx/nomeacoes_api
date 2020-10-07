using System;

namespace Api.Domain.Dtos.Election
{
    public class ElectionDtoUpdateResult
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public DateTime UpdateAt { get; set; }
    }
}
