using System;

namespace Api.Domain.Dtos.Office
{
    public class OfficeDtoCreateResult
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public Guid ElectionId { get; set; }
        public int QtdeAssociates { get; set; }
        public DateTime CreateAt { get; set; }
    }
}
