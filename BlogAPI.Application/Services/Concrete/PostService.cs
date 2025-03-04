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
    public class PostService : Service<PostDto, Post>, IPostService
    {
        private readonly IRepository<Post> _repository;
        private readonly IMapper _mapper;
        public PostService(IRepository<Post> repository, IMapper mapper) : base(repository, mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<List<PostDto>> GetPostsByCategoryAsync(int categoryId)
        {
            var post = await _repository.GetAllAsync();
            var filteredPosts = post.Where(c => c.CategoryId == categoryId).ToList();
            return _mapper.Map<List<PostDto>>(filteredPosts);
        }
    }
}
