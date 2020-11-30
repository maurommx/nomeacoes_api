using System.Threading.Tasks;
using Api.Domain.Entities;
using Api.Domain.Interfaces;
using System.Collections.Generic;

namespace Api.Domain.Repository
{
    public interface IOfficeRepository : IRepository<OfficeEntity>
    {
        Task<IEnumerable<OfficeEntity>> SelectFullAsync();
    }
}
