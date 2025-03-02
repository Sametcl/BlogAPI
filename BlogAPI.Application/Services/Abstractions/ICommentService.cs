using BlogAPI.Domain.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogAPI.Application.Services.Abstractions
{
    public interface ICommentService
    {
        Task<CommentDto> CreateCommentAsync(CommentDto commentDto);   
        Task<bool> UpdatedCommentAsync(int id, CommentDto commentDto);
        Task<List<CommentDto>> GetCommentByPostIdAsync(int postid);
        Task<bool> DeleteCommentAsync(int id);
        Task<CommentDto> GetCommentByIdAsync(int id);   

    }
}
