using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Api.Domain.Dtos.Office;

namespace Api.Domain.Interfaces.Services.Office
{
    public interface IOfficeService
    {
        Task<OfficeDto> Get(Guid id);
        Task<IEnumerable<OfficeDto>> GetAll();
        Task<OfficeDtoCreateResult> Post(OfficeDtoCreate office);
        Task<OfficeDtoUpdateResult> Put(OfficeDtoUpdate office);
        Task<bool> Delete(Guid id);
    }
}
