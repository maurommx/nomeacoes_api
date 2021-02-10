using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Api.Domain.Dtos.Permission;
using Api.Domain.Entities;
using Api.Domain.Interfaces;
using Api.Domain.Interfaces.QueryOptions;
using Api.Domain.Interfaces.Services.Permission;
using Api.Domain.Models;
using AutoMapper;

namespace Api.Service.Services
{
    public class PermissionService : IPermissionService
    {
        private IRepository<PermissionEntity> _repository;
        private readonly IMapper _mapper;

        public PermissionService(IRepository<PermissionEntity> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<bool> Delete(Guid id)
        {
            return await _repository.DeleteAsync(id);
        }

        public async Task<PermissionDto> Get(Guid id)
        {
            var entity = await _repository.SelectAsync(id);
            return _mapper.Map<PermissionDto>(entity);
            // var model = _mapper.Map<ElectionModel>(dto);
            // var aaa = entity.Offices;
            // return dto;
        }

        public async Task<IQueryOptions> GetAll(IQueryOptions query)
        {
            var listEntity = await _repository.SelectAsync(query);
            query.Rows = _mapper.Map<IEnumerable<PermissionDto>>(listEntity.Rows);
            return query;
        }

        public async Task<PermissionDto> Post(PermissionDto permission)
        {
            var model = _mapper.Map<PermissionModel>(permission);
            var entity = _mapper.Map<PermissionEntity>(model);
            var result = await _repository.InsertAsync(entity);

            return _mapper.Map<PermissionDto>(result);
        }

        public async Task<PermissionDto> Put(PermissionDto permission)
        {
            var model = _mapper.Map<PermissionModel>(permission);
            var entity = _mapper.Map<PermissionEntity>(model);

            var result = await _repository.UpdateAsync(entity);
            return _mapper.Map<PermissionDto>(result);
        }
    }
}
