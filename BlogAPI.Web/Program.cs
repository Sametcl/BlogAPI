using BlogAPI.Application.AutoMapper;
using BlogAPI.Application.Services.Concrete;
using BlogAPI.Application.Services.Interface;
using BlogAPI.Application.Validators;
using BlogAPI.Domain.DTOs;
using BlogAPI.Domain.Entities;
using BlogAPI.Infrastructure.Interfaces;
using BlogAPI.Infrastructure.Presistence;
using BlogAPI.Infrastructure.Repositories;
using FluentValidation;
using Microsoft.EntityFrameworkCore;

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
builder.Services.AddScoped<IService<CategoryDto>, Service<CategoryDto, Category>>();

//Map
builder.Services.AddAutoMapper(typeof(MappingProfile));

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Validations
builder.Services.AddScoped<IValidator<PostDto>, PostValidator>();
builder.Services.AddScoped<IValidator<CategoryDto>, CategoryValidator>();


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
