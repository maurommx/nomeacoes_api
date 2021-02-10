using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Api.Domain.Dtos.Office;
using Api.Domain.Entities;
using Api.Domain.Interfaces;
using Api.Domain.Interfaces.QueryOptions;
using Api.Domain.Interfaces.Services.Office;
using Api.Domain.Models;
using Api.Domain.Repository;
using AutoMapper;

namespace Api.Service.Services
{
    public class OfficeService : IOfficeService
    {
        private IOfficeRepository _repository;
        private readonly IMapper _mapper;

        public OfficeService(IOfficeRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<bool> Delete(Guid id)
        {
            return await _repository.DeleteAsync(id);
        }

        public async Task<OfficeDto> Get(Guid id)
        {
            var entity = await _repository.SelectAsync(id);
            return _mapper.Map<OfficeDto>(entity);
        }

        public async Task<IQueryOptions> GetAll(IQueryOptions query)
        {
            var listEntity = await _repository.SelectAsync(query);
            query.Rows = _mapper.Map<IEnumerable<OfficeDto>>(listEntity.Rows);
            return query;
        }
        public async Task<IEnumerable<OfficeDto>> GetAllWithInclude()
        {
            var listEntity = await _repository.SelectFullAsync();
            return _mapper.Map<IEnumerable<OfficeDto>>(listEntity);
        }


        public async Task<OfficeDtoCreateResult> Post(OfficeDtoCreate office)
        {
            var model = _mapper.Map<OfficeModel>(office);
            var entity = _mapper.Map<OfficeEntity>(model);
            var result = await _repository.InsertAsync(entity);

            return _mapper.Map<OfficeDtoCreateResult>(result);
        }

        public async Task<OfficeDtoUpdateResult> Put(OfficeDtoUpdate office)
        {
            var model = _mapper.Map<OfficeModel>(office);
            var entity = _mapper.Map<OfficeEntity>(model);

            var result = await _repository.UpdateAsync(entity);
            return _mapper.Map<OfficeDtoUpdateResult>(result);
        }
    }
}
