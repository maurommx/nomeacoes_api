using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Api.Domain.Dtos.Member;

namespace Api.Domain.Interfaces.Services.Member
{
    public interface IMemberService
    {
        Task<MemberDto> Get(Guid id);
        Task<IEnumerable<MemberDto>> GetAll();
        Task<MemberDtoCreateResult> Post(MemberDtoCreate member);
        Task<MemberDtoUpdateResult> Put(MemberDtoUpdate member);
        Task<bool> Delete(Guid id);
    }
}
