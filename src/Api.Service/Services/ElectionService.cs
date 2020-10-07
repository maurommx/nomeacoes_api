using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Api.Domain.Dtos.Election;
using Api.Domain.Entities;
using Api.Domain.Interfaces;
using Api.Domain.Interfaces.Services.Election;
using Api.Domain.Models;
using AutoMapper;

namespace Api.Service.Services
{
    public class ElectionService : IElectionService
    {
        private IRepository<ElectionEntity> _repository;
        private readonly IMapper _mapper;

        public ElectionService(IRepository<ElectionEntity> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<bool> Delete(Guid id)
        {
            return await _repository.DeleteAsync(id);
        }

        public async Task<ElectionDto> Get(Guid id)
        {
            var entity = await _repository.SelectAsync(id);
            return _mapper.Map<ElectionDto>(entity);
            // var model = _mapper.Map<ElectionModel>(dto);
            // var aaa = entity.Offices;
            // return dto;
        }

        public async Task<IEnumerable<ElectionDto>> GetAll()
        {
            var listEntity = await _repository.SelectAsync();
            return _mapper.Map<IEnumerable<ElectionDto>>(listEntity);
        }

        public async Task<ElectionDtoCreateResult> Post(ElectionDtoCreate election)
        {
            var model = _mapper.Map<ElectionModel>(election);
            var entity = _mapper.Map<ElectionEntity>(model);
            var result = await _repository.InsertAsync(entity);

            return _mapper.Map<ElectionDtoCreateResult>(result);
        }

        public async Task<ElectionDtoUpdateResult> Put(ElectionDtoUpdate election)
        {
            var model = _mapper.Map<ElectionModel>(election);
            var entity = _mapper.Map<ElectionEntity>(model);

            var result = await _repository.UpdateAsync(entity);
            return _mapper.Map<ElectionDtoUpdateResult>(result);
        }
    }
}
