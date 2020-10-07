using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Api.Domain.Dtos.Associate;
using Api.Domain.Entities;
using Api.Domain.Interfaces;
using Api.Domain.Interfaces.Services.Associate;
using Api.Domain.Models;
using AutoMapper;

namespace Api.Service.Services
{
    public class AssociateService : IAssociateService
    {
        private IRepository<AssociateEntity> _repository;
        private readonly IMapper _mapper;

        public AssociateService(IRepository<AssociateEntity> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<bool> Delete(Guid id)
        {
            return await _repository.DeleteAsync(id);
        }

        public async Task<AssociateDto> Get(Guid id)
        {
            var entity = await _repository.SelectAsync(id);
            return _mapper.Map<AssociateDto>(entity);
        }

        public async Task<IEnumerable<AssociateDto>> GetAll()
        {
            var listEntity = await _repository.SelectAsync();
            return _mapper.Map<IEnumerable<AssociateDto>>(listEntity);
        }

        public async Task<AssociateDtoCreateResult> Post(AssociateDtoCreate associate)
        {
            var model = _mapper.Map<AssociateModel>(associate);
            var entity = _mapper.Map<AssociateEntity>(model);
            var result = await _repository.InsertAsync(entity);

            return _mapper.Map<AssociateDtoCreateResult>(result);
        }

        public async Task<AssociateDtoUpdateResult> Put(AssociateDtoUpdate associate)
        {
            var model = _mapper.Map<AssociateModel>(associate);
            var entity = _mapper.Map<AssociateEntity>(model);

            var result = await _repository.UpdateAsync(entity);
            return _mapper.Map<AssociateDtoUpdateResult>(result);
        }
    }
}
