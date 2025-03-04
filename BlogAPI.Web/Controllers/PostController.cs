using BlogAPI.Application.Services.Concrete;
using BlogAPI.Application.Services.Interface;
using BlogAPI.Domain.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BlogAPI.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostController : ControllerBase
    {
        
        private readonly ICommentService _commentService;

        private readonly IPostService _postService;
        public PostController(ICommentService commentService, IPostService postService)
        {
            _commentService = commentService;
            _postService = postService;
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
            if (postDto == null)
                return BadRequest("Post verisi geçersiz.");

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
