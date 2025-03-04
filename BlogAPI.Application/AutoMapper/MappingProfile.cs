using AutoMapper;
using BlogAPI.Domain.DTOs;
using BlogAPI.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogAPI.Application.AutoMapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Category, CategoryDto>().ReverseMap();
            CreateMap<Post, PostDto>()
            .ForMember(dest => dest.Comments, opt => opt.MapFrom(src => src.Comments.Select(c => c.Text).ToList()));
            CreateMap<PostDto, Post>();

            CreateMap<Comment, CommentDto>();
            CreateMap<CommentDto, Comment>();
        }
    }
}
