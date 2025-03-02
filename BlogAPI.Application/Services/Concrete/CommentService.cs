using AutoMapper;
using BlogAPI.Application.Services.Abstractions;
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
    public class CommentService : ICommentService
    {
        private readonly ICommentRepository _repository;
        private readonly IMapper _mapper;

        public CommentService(ICommentRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<CommentDto> CreateCommentAsync(CommentDto commentDto)
        {
            if (commentDto == null)
            {
                throw new Exception("Comment cannot be null");
            }
            var comment = _mapper.Map<Comment>(commentDto);
            await _repository.AddAync(comment);
            return _mapper.Map<CommentDto>(comment);
        }

        public async Task<bool> DeleteCommentAsync(int id)
        {
            var comment = await _repository.GetByIdAsync(id);
            if (comment == null)
            {
                return false;
            }
            await _repository.DeleteAync(id);
            return true;

        }

        public async Task<CommentDto> GetCommentByIdAsync(int id)
        {
            var comment = await _repository.GetByIdAsync(id);
            if (comment==null)
            {
                throw new Exception("comment not found");
            }
            return _mapper.Map<CommentDto>(comment);

        }

        public async Task<List<CommentDto>> GetCommentByPostIdAsync(int postid)
        {
            var comments = await _repository.GetCommentByPostIdAsync(postid);
            return _mapper.Map<List<CommentDto>>(comments);
        }

        public async Task<bool> UpdatedCommentAsync(int id, CommentDto commentDto)
        {
            var comment = await _repository.GetByIdAsync(id);
            if (comment == null)
            {
                return false;  
            }
            _mapper.Map(commentDto, comment);
            await _repository.UpdateAync(comment);
            return true;
        }
    }
}
