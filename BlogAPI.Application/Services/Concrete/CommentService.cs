using AutoMapper;
using BlogAPI.Application.Services.Interface;
using BlogAPI.Domain.DTOs;
using BlogAPI.Domain.Entities;
using BlogAPI.Infrastructure.Interfaces;
using BlogAPI.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogAPI.Application.Services.Concrete
{
    public class CommentService : Service<CommentDto, Comment>, ICommentService
    {
        private readonly IRepository<Comment> _repository;
        private readonly IMapper _mapper;

        public CommentService(IRepository<Comment> repository, IMapper mapper) : base(repository, mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<List<CommentDto>> GetCommentsByPostAsync(int postId)
        {
            var comments = await _repository.GetAllAsync();
            var filteredComments = comments.Where(c => c.PostId == postId).ToList();
            return _mapper.Map<List<CommentDto>>(filteredComments);
        }
    }
}
