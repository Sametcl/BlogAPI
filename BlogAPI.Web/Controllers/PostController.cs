using BlogAPI.Application.Services.Concrete;
using BlogAPI.Application.Services.Interface;
using BlogAPI.Domain.DTOs;
using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;


namespace BlogAPI.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostController : ControllerBase
    {

        private readonly ICommentService _commentService;
        private readonly IValidator<PostDto> _validator;
        private readonly IPostService _postService;
        public PostController(ICommentService commentService, IPostService postService, IValidator<PostDto> validator)
        {
            _commentService = commentService;
            _postService = postService;
            _validator = validator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var posts = await _postService.GetAllAsync();
            return Ok(posts);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var post = await _postService.GetByIdAsync(id);
            if (post == null)
                return NotFound();
            return Ok(post);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] PostDto postDto)
        {
            var validationresult = _validator.Validate(postDto);
            if (!validationresult.IsValid)
            {
                return StatusCode(400,validationresult.Errors);
            }


            await _postService.AddAsync(postDto);
            return CreatedAtAction(nameof(GetById), new { id = postDto.Id }, postDto);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] PostDto postDto)
        {
            if (postDto == null || id != postDto.Id)
                return BadRequest("Geçersiz veri.");

            await _postService.UpdateAsync(postDto);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _postService.DeleteAsync(id);
            return NoContent();
        }

        [HttpGet("{postId}/comments")]
        public async Task<IActionResult> GetCommentsByPost(int postId)
        {
            // Yorumları al
            var comments = await _commentService.GetCommentsByPostAsync(postId);
            if (comments == null || !comments.Any())
                return NotFound("Bu post için yorum bulunamadı.");

            return Ok(comments);
        }
    }
}
