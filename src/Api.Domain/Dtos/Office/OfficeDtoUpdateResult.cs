using System;
using Api.Domain.Dtos.Election;

namespace Api.Domain.Dtos.Office
{
    public class OfficeDtoUpdateResult
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public Guid ElectionId { get; set; }
        public ElectionDto Election { get; set; }
        public int QtdeAssociates { get; set; }
        public DateTime UpdateAt { get; set; }
    }
}
