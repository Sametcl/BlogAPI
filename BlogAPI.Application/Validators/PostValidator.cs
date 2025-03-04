using BlogAPI.Domain.DTOs;
using FluentValidation;

namespace BlogAPI.Application.Validators
{
    public class PostValidator :AbstractValidator<PostDto>
    {
        public PostValidator()
        {
            RuleFor(x => x.Title)
                .NotEmpty().WithMessage("Baslik bos olamaz")
                .MinimumLength(5).WithMessage("Baslik 5 karakterden uzun olmali ");
            RuleFor(x => x.Content)
                .NotEmpty().WithMessage("Icerik bos olamaz")
                .MinimumLength(25).WithMessage("Icerik 25 karakterden uzun olmali ");
        }
    }
}
