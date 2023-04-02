using FluentValidation;
using IdentityMicroservice.Domain.DTOs;

namespace IdentityMicroservice.Domain.Validators;

public class LoginDtoValidator: AbstractValidator<LoginDto>
{
    public LoginDtoValidator()
    {
        RuleFor(x => x.Email).NotEmpty().WithMessage("Please provide an email!");
        RuleFor(x => x.Password).NotEmpty().WithMessage("Please provide a password!");
    }
}