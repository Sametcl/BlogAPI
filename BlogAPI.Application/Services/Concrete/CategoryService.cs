using AutoMapper;
using BlogAPI.Application.Services.Abstractions;
using BlogAPI.Domain.DTOs;
using BlogAPI.Domain.Entities;
using BlogAPI.Infrastructure.Interfaces;
using System.Runtime.CompilerServices;

namespace BlogAPI.Application.Services.Concrete
{
    public class CategoryService : ICategoryService
    {
        private readonly IRepository<Category> _repository;
        private readonly IMapper _mapper;

        public CategoryService(IRepository<Category> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<CategoryDto> CreateCategoryAsync(CategoryDto categoryDto)
        {
            if (categoryDto == null)
            {
                throw new Exception( "Kategori bos olamaz!");
            }

            var category = _mapper.Map<Category>(categoryDto);
            await _repository.AddAync(category);
            return _mapper.Map<CategoryDto>(category);  
        }

        public async Task<bool> DeleteCategoryAsync(int id)
        {
            var category = await _repository.GetByIdAsync(id);
            if (category == null)
            {
                return false;  
            }

            await _repository.DeleteAync(id);
            return true;
        }

        public async Task<List<CategoryDto>> GetAllCategoriesAsync()
        {
            var categories = await _repository.GetAllAsync();
            return _mapper.Map<List<CategoryDto>>(categories);
        }

        public async Task<CategoryDto> GetCategoryByIdAsync(int id)
        {
            var category = await _repository.GetByIdAsync(id);
            if (category == null)
            {
                throw new Exception($"Category with ID {id} not found.");
            }

            return _mapper.Map<CategoryDto>(category);
        }

        public async Task<bool> UpdateCategoryAsync(int id, CategoryDto categoryDto)
        {
            var existingCategory = await _repository.GetByIdAsync(id);
            if (existingCategory == null)
            {
                return false;  
            }

            var updatedCategory = _mapper.Map(categoryDto, existingCategory);
            await _repository.UpdateAync(updatedCategory);
            return true;
        }
    }
}
