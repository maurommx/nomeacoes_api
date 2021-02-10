using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Api.Domain.Dtos.Office;
using Api.Domain.Interfaces.QueryOptions;

namespace Api.Domain.Interfaces.Services.Office
{
    public interface IOfficeService
    {
        Task<OfficeDto> Get(Guid id);
        Task<IQueryOptions> GetAll(IQueryOptions query);
        Task<IEnumerable<OfficeDto>> GetAllWithInclude();
        Task<OfficeDtoCreateResult> Post(OfficeDtoCreate office);
        Task<OfficeDtoUpdateResult> Put(OfficeDtoUpdate office);
        Task<bool> Delete(Guid id);
    }
}
