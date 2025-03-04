using BlogAPI.Domain.Entities;
using BlogAPI.Infrastructure.Interfaces;
using BlogAPI.Infrastructure.Presistence;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogAPI.Infrastructure.Repositories
{
    public class CommentRepository : ICommentRepository
    {
        private readonly BlogDbContext _context;

        public CommentRepository(BlogDbContext context)
        {
            _context = context;
        }

        public async Task AddAync(Comment entity)
        {
            await _context.Comments.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAync(int id)
        {
            var entity = await _context.Comments.FindAsync(id);
            if (entity != null)
            {
                _context.Comments.Remove(entity);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<Comment>> GetAllAsync()
        {
            return await _context.Comments.ToListAsync();
        }

        public async Task<Comment> GetByIdAsync(int id)
        {
            return await _context.Comments.FindAsync(id);
        }

        public async Task<List<Comment>> GetCommentByPostIdAsync(int postId)
        {
            return await _context.Comments.Where(c => c.PostId == postId).ToListAsync();
        }

        public async Task UpdateAync(Comment entity)
        {
            _context.Comments.Update(entity);
            await _context.SaveChangesAsync();
        }
    }
}
