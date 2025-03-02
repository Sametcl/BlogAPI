using BlogAPI.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogAPI.Infrastructure.Interfaces
{
    public interface ICommentRepository:IRepository<Comment>
    {
        Task<List<Comment>> GetCommentByPostIdAsync(int postId);
    }
}
