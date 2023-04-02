using FluentValidation;
using IdentityMicroservice.Domain.DTOs;
using System.Text.RegularExpressions;

namespace IdentityMicroservice.Domain.Validators;

public class RegisterDtoValidator: AbstractValidator<RegisterDto>
{
    public RegisterDtoValidator()
    {
        RuleFor(x => x.Email).EmailAddress().WithMessage("Please provide a valid email!");
        RuleFor(x => x.Password).Must(BeAValidPassword).WithMessage("Please provide a valid password!");
        RuleFor(x => x.FirstName).NotEmpty().WithMessage("First name is empty!");
        RuleFor(x => x.LastName).NotEmpty().WithMessage("Last name is empty!");
    }
    private bool BeAValidPassword(string? password)
    {
        const string pattern = "^(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9])(?=.*?[#?!@$%^&*-]).{8,}$";
        Regex regex = new Regex(pattern);
        return password != null && regex.IsMatch(password);
    }
}