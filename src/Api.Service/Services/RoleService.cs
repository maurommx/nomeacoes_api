using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Api.Domain.Dtos.Role;
using Api.Domain.Entities;
using Api.Domain.Interfaces;
using Api.Domain.Interfaces.QueryOptions;
using Api.Domain.Interfaces.Services.Role;
using Api.Domain.Models;
using AutoMapper;

namespace Api.Service.Services
{
    public class RoleService : IRoleService
    {
        private IRepository<RoleEntity> _repository;
        private readonly IMapper _mapper;

        public RoleService(IRepository<RoleEntity> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<bool> Delete(Guid id)
        {
            return await _repository.DeleteAsync(id);
        }

        public async Task<RoleDto> Get(Guid id)
        {
            var entity = await _repository.SelectAsync(id);
            return _mapper.Map<RoleDto>(entity);
            // var model = _mapper.Map<ElectionModel>(dto);
            // var aaa = entity.Offices;
            // return dto;
        }

        public async Task<IQueryOptions> GetAll(IQueryOptions query)
        {
            var listEntity = await _repository.SelectAsync(query);
            query.Rows = _mapper.Map<IEnumerable<RoleDto>>(listEntity.Rows);
            return query;
        }

        public async Task<RoleDto> Post(RoleDto role)
        {
            var model = _mapper.Map<RoleModel>(role);
            var entity = _mapper.Map<RoleEntity>(model);
            var result = await _repository.InsertAsync(entity);

            return _mapper.Map<RoleDto>(result);
        }

        public async Task<RoleDto> Put(RoleDto role)
        {
            var model = _mapper.Map<RoleModel>(role);
            var entity = _mapper.Map<RoleEntity>(model);

            var result = await _repository.UpdateAsync(entity);
            return _mapper.Map<RoleDto>(result);
        }
    }
}
