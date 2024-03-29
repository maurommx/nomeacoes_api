using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Api.Domain.Dtos.Associate;
using Api.Domain.Interfaces.QueryOptions;

namespace Api.Domain.Interfaces.Services.Associate
{
    public interface IAssociateService
    {
        Task<AssociateDto> Get(Guid id);
        Task<IQueryOptions> GetAll(IQueryOptions query);
        Task<AssociateDtoCreateResult> Post(AssociateDtoCreate associate);
        Task<AssociateDtoUpdateResult> Put(AssociateDtoUpdate associate);
        Task<bool> Delete(Guid id);
    }
}
