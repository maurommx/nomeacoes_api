using System;
using System.Collections.Generic;
using Api.Domain.Dtos.Office;

namespace Api.Domain.Dtos.Election
{
    public class ElectionDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public DateTime CreateAt { get; set; }
        public IEnumerable<OfficeDto> Offices { get; set; } //Cargos
    }
}
