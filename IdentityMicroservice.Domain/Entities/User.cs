using FluentValidation;
using IdentityMicroservice.Domain.DTOs;
using IdentityMicroservice.Domain.Validators;
using Microsoft.AspNetCore.Identity;

namespace IdentityMicroservice.Domain.Entities;

public class User : IdentityUser
{
    public string? FirstName { get; set; }
    public string? LastName { get; set; }

}