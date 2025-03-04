using BlogAPI.Application.AutoMapper;
using BlogAPI.Application.Services.Concrete;
using BlogAPI.Application.Services.Interface;
using BlogAPI.Domain.DTOs;
using BlogAPI.Infrastructure.Interfaces;
using BlogAPI.Infrastructure.Presistence;
using BlogAPI.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

using BlogAPI.Application.AutoMapper;
using BlogAPI.Application.Services.Concrete;
using BlogAPI.Application.Services.Interface;
using BlogAPI.Domain.DTOs;
using BlogAPI.Infrastructure.Interfaces;
using BlogAPI.Infrastructure.Presistence;
using BlogAPI.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using BlogAPI.Domain.Entities;

var builder = WebApplication.CreateBuilder(args);

// DbContext
builder.Services.AddDbContext<BlogDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Repositories
builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));

// Services
builder.Services.AddScoped<ICommentService, CommentService>();
builder.Services.AddScoped<IPostService, PostService>();
builder.Services.AddScoped<IService<PostDto>, Service<PostDto, Post>>();

builder.Services.AddAutoMapper(typeof(MappingProfile));

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
