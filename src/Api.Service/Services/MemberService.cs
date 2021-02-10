using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Api.Domain.Dtos.Member;
using Api.Domain.Entities;
using Api.Domain.Interfaces;
using Api.Domain.Interfaces.QueryOptions;
using Api.Domain.Interfaces.Services.Member;
using Api.Domain.Models;
using AutoMapper;

namespace Api.Service.Services
{
    public class MemberService : IMemberService
    {
        private IRepository<MemberEntity> _repository;
        private readonly IMapper _mapper;

        public MemberService(IRepository<MemberEntity> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<bool> Delete(Guid id)
        {
            return await _repository.DeleteAsync(id);
        }

        public async Task<MemberDto> Get(Guid id)
        {
            var entity = await _repository.SelectAsync(id);
            return _mapper.Map<MemberDto>(entity);
        }

        public async Task<IQueryOptions> GetAll(IQueryOptions query)
        {
            var listEntity = await _repository.SelectAsync(query);
            query.Rows = _mapper.Map<IEnumerable<MemberDto>>(listEntity.Rows);
            return query;
        }


        public async Task<MemberDtoCreateResult> Post(MemberDtoCreate member)
        {
            var model = _mapper.Map<UserModel>(member);
            var entity = _mapper.Map<MemberEntity>(model);
            var result = await _repository.InsertAsync(entity);

            return _mapper.Map<MemberDtoCreateResult>(result);
        }

        public async Task<MemberDtoUpdateResult> Put(MemberDtoUpdate member)
        {
            var model = _mapper.Map<UserModel>(member);
            var entity = _mapper.Map<MemberEntity>(model);

            var result = await _repository.UpdateAsync(entity);
            return _mapper.Map<MemberDtoUpdateResult>(result);
        }
    }
}
