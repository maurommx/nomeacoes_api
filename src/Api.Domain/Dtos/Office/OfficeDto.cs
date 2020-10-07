using System;
using System.Collections.Generic;
using Api.Domain.Dtos.Associate;
using Api.Domain.Dtos.Elected;
using Api.Domain.Dtos.Election;

namespace Api.Domain.Dtos.Office
{
    public class OfficeDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public Guid ElectionId { get; set; }
        public ElectionDto Election { get; set; }
        public int QtdeAssociates { get; set; }
        public DateTime CreateAt { get; set; }
    }
}
