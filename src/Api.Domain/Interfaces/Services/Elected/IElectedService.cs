using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Api.Domain.Dtos.Elected;

namespace Api.Domain.Interfaces.Services.Elected
{
    public interface IElectedService
    {
        Task<ElectedDto> Get(Guid id);
        Task<IEnumerable<ElectedDto>> GetAll();
        Task<ElectedDtoCreateResult> Post(ElectedDtoCreate elected);
        Task<ElectedDtoUpdateResult> Put(ElectedDtoUpdate elected);
        Task<bool> Delete(Guid id);
    }
}
