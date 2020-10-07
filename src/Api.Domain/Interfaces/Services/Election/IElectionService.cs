using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Api.Domain.Dtos.Election;

namespace Api.Domain.Interfaces.Services.Election
{
    public interface IElectionService
    {
        Task<ElectionDto> Get(Guid id);
        Task<IEnumerable<ElectionDto>> GetAll();
        Task<ElectionDtoCreateResult> Post(ElectionDtoCreate election);
        Task<ElectionDtoUpdateResult> Put(ElectionDtoUpdate election);
        Task<bool> Delete(Guid id);
    }
}
