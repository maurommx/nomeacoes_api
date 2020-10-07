using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Api.Domain.Dtos.Elected;
using Api.Domain.Entities;
using Api.Domain.Interfaces;
using Api.Domain.Interfaces.Services.Elected;
using Api.Domain.Models;
using AutoMapper;

namespace Api.Service.Services
{
    public class ElectedService : IElectedService
    {
        private IRepository<ElectedEntity> _repository;
        private readonly IMapper _mapper;

        public ElectedService(IRepository<ElectedEntity> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<bool> Delete(Guid id)
        {
            return await _repository.DeleteAsync(id);
        }

        public async Task<ElectedDto> Get(Guid id)
        {
            var entity = await _repository.SelectAsync(id);
            return _mapper.Map<ElectedDto>(entity);
        }

        public async Task<IEnumerable<ElectedDto>> GetAll()
        {
            var listEntity = await _repository.SelectAsync();
            return _mapper.Map<IEnumerable<ElectedDto>>(listEntity);
        }

        public async Task<ElectedDtoCreateResult> Post(ElectedDtoCreate elected)
        {
            var model = _mapper.Map<ElectedModel>(elected);
            var entity = _mapper.Map<ElectedEntity>(model);
            var result = await _repository.InsertAsync(entity);

            return _mapper.Map<ElectedDtoCreateResult>(result);
        }

        public async Task<ElectedDtoUpdateResult> Put(ElectedDtoUpdate elected)
        {
            var model = _mapper.Map<ElectedDto>(elected);
            var entity = _mapper.Map<ElectedEntity>(model);

            var result = await _repository.UpdateAsync(entity);
            return _mapper.Map<ElectedDtoUpdateResult>(result);
        }
    }
}
