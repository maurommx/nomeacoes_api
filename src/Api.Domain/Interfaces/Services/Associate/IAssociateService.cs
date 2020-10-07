using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Api.Domain.Dtos.Associate;

namespace Api.Domain.Interfaces.Services.Associate
{
    public interface IAssociateService
    {
        Task<AssociateDto> Get(Guid id);
        Task<IEnumerable<AssociateDto>> GetAll();
        Task<AssociateDtoCreateResult> Post(AssociateDtoCreate associate);
        Task<AssociateDtoUpdateResult> Put(AssociateDtoUpdate associate);
        Task<bool> Delete(Guid id);
    }
}
