using BlogAPI.Application.Services.Interface;
using BlogAPI.Domain.DTOs;
using FluentValidation;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace BlogAPI.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly IService<CategoryDto> _service;
        private readonly IValidator<CategoryDto> _validator;
        public CategoryController(IService<CategoryDto> service, IValidator<CategoryDto> validator)
        {
            _service = service;
            _validator = validator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var categories = await _service.GetAllAsync();
            return Ok(categories);
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var category = await _service.GetByIdAsync(id);
            if (category == null)
            {
                return NotFound();
            }
            return Ok(category);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CategoryDto categoryDto)
        {
            var validator = _validator.Validate(categoryDto);
            if (!validator.IsValid)
            {
                return BadRequest(validator.Errors);
            }
            await _service.AddAsync(categoryDto);
            return Ok(new { message = "Basarili sekilde kaydedildi" });
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, CategoryDto categoryDto)
        {
            if (categoryDto==null || id!=categoryDto.Id )
            {
                return BadRequest(new { message = "gecersiz veri " });
            }
            await _service.UpdateAsync(categoryDto);
            return NoContent();
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            await _service.DeleteAsync(id);
            return NoContent();
        }
    }

}
