using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Api.Domain.Dtos.Election;
using Api.Domain.Interfaces.QueryOptions;

namespace Api.Domain.Interfaces.Services.Election
{
    public interface IElectionService
    {
        Task<ElectionDto> Get(Guid id);
        Task<IQueryOptions> GetAll(IQueryOptions query);
        Task<ElectionDtoCreateResult> Post(ElectionDtoCreate election);
        Task<ElectionDtoUpdateResult> Put(ElectionDtoUpdate election);
        Task<bool> Delete(Guid id);
    }
}
