using System.ComponentModel.DataAnnotations;
using FluentValidation;
using IdentityMicroservice.Domain.Validators;

namespace IdentityMicroservice.Domain.DTOs;

public class RegisterDto
{
    public static RegisterDtoValidator Validator => new(); 
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string? Email { get; set; }
    public string? Password { get; set; }
    public bool IsAdmin { get; set; } = false;
    public async Task ValidateAndThrow()
    {
        await Validator.ValidateAndThrowAsync(this);
    }
}