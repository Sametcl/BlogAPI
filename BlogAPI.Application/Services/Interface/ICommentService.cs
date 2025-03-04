using BlogAPI.Domain.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogAPI.Application.Services.Interface
{
    public interface ICommentService:IService<CommentDto>
    {
        Task<List<CommentDto>> GetCommentsByPostAsync(int postId);
    }
}
