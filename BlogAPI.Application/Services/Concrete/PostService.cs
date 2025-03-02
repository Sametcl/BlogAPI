using AutoMapper;
using BlogAPI.Application.Services.Abstractions;
using BlogAPI.Domain.DTOs;
using BlogAPI.Domain.Entities;
using BlogAPI.Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogAPI.Application.Services.Concrete
{
    public class PostService : IPostService
    {
        private readonly IRepository<Post> _repository;
        private readonly IMapper _mapper;

        public PostService(IRepository<Post> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<PostDto> CreatePostAsync(PostDto postDto)
        {
            if (postDto == null)
            {
                throw new ArgumentNullException(nameof(postDto), "Post bilgileri boş olamaz.");
            }

            var postEntity = _mapper.Map<Post>(postDto);
            await _repository.AddAync(postEntity);

            return _mapper.Map<PostDto>(postEntity);
        }

        public async Task<bool> DeletePostAsync(int id)
        {
            var post = await _repository.GetByIdAsync(id);
            if (post == null)
            {
                throw new KeyNotFoundException($"ID {id} ile eşleşen bir post bulunamadı.");
            }

            await _repository.DeleteAync(id);
            return true;
        }

        public async Task<List<PostDto>> GetAllPostsAsync()
        {
            var posts = await _repository.GetAllAsync();
            return _mapper.Map<List<PostDto>>(posts);
        }

        public async Task<PostDto> GetPostByIdAsync(int id)
        {
            var post = await _repository.GetByIdAsync(id);
            if (post == null)
            {
                throw new KeyNotFoundException($"ID {id} ile eşleşen bir post bulunamadı.");
            }

            return _mapper.Map<PostDto>(post);
        }

        public async Task<bool> UpdatePostAsync(int id, PostDto postDto)
        {
            var post = await _repository.GetByIdAsync(id);
            if (post == null)
            {
                throw new KeyNotFoundException($"ID {id} ile eşleşen bir post bulunamadı.");
            }

            _mapper.Map(postDto, post);
            await _repository.UpdateAync(post);

            return true;
        }
    }
}
