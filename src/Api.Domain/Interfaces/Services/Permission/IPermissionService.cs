using System;
using System.Threading.Tasks;
using Api.Domain.Dtos.Permission;
using Api.Domain.Interfaces.QueryOptions;

namespace Api.Domain.Interfaces.Services.Permission
{
    public interface IPermissionService
    {
        Task<PermissionDto> Get(Guid id);
        Task<IQueryOptions> GetAll(IQueryOptions query);
        Task<PermissionDto> Post(PermissionDto member);
        Task<PermissionDto> Put(PermissionDto member);
        Task<bool> Delete(Guid id);
    }
}
