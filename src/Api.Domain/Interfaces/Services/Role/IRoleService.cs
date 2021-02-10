using System;
using System.Threading.Tasks;
using Api.Domain.Dtos.Role;
using Api.Domain.Interfaces.QueryOptions;

namespace Api.Domain.Interfaces.Services.Role
{
    public interface IRoleService
    {
        Task<RoleDto> Get(Guid id);
        Task<IQueryOptions> GetAll(IQueryOptions query);
        Task<RoleDto> Post(RoleDto member);
        Task<RoleDto> Put(RoleDto member);
        Task<bool> Delete(Guid id);
    }
}
