using BlogAPI.Domain.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogAPI.Application.Services.Abstractions
{
    public interface IPostService
    {
        Task<PostDto> CreatePostAsync(PostDto postDto);
        Task<bool> DeletePostAsync(int id);
        Task<List<PostDto>> GetAllPostsAsync();
        Task<PostDto> GetPostByIdAsync(int id);
        Task<bool> UpdatePostAsync(int id, PostDto postDto);
    }

}
