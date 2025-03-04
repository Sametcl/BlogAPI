using AutoMapper;
using BlogAPI.Application.Services.Interface;
using BlogAPI.Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogAPI.Application.Services.Concrete
{
    public class Service<TDto, TEntity> : IService<TDto>
        where TEntity : class
        where TDto : class
    {
        private readonly IMapper _mapper;
        private readonly IRepository<TEntity> _repository;

        public Service(IRepository<TEntity> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task AddAsync(TDto entity)
        {
            if (entity==null)
            {
                throw new Exception("bos alanlari doldurun");
            }
            var map = _mapper.Map<TEntity>(entity);
            await _repository.AddAync(map);
        }

        public async Task DeleteAsync(int id)
        {
            var entity=await _repository.GetByIdAsync(id);
            if (entity==null)
            {
                throw new Exception("silinecek id bulunamadi");
            }
            await _repository.DeleteAync(entity);
        }

        public async Task<List<TDto>> GetAllAsync()
        {
            var entities=await _repository.GetAllAsync();
            return _mapper.Map<List<TDto>>(entities);
        }

        public async Task<TDto> GetByIdAsync(int id)
        {
            var entity= await _repository.GetByIdAsync(id);
            if (entity==null)
            {
                throw new Exception("bu id'e ait veri bulunmadi");
            }
            var map= _mapper.Map<TDto>(entity);
            return map;

        }

        public async Task UpdateAsync(TDto entity)
        {
            if (entity == null)
            {
                throw new Exception("bos alanlari doldurun");
            }
            var map = _mapper.Map<TEntity>(entity);
            await _repository.UpdateAync(map);
        }
    }
}
