using IdentityMicroservice.Domain.DTOs;

namespace IdentityMicroservice.Repository.Contracts;

public interface IUserRepository
{
    public Task<string> Login(LoginDto loginDto);
    public Task<bool> Register(RegisterDto registerDto);
}