using IdentityMicroservice.Domain.DTOs;

namespace IdentityMicroservice.Business.Contracts;

public interface IUserBusinessLogic
{
    public Task<string> Login(LoginDto loginDto);
    public Task<bool> Register(RegisterDto registerDto);
}