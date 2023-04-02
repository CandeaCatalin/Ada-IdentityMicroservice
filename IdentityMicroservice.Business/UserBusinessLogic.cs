using IdentityMicroservice.Business.Contracts;
using IdentityMicroservice.Domain.DTOs;
using IdentityMicroservice.Domain.Entities;
using IdentityMicroservice.Repository.Contracts;

namespace IdentityMicroservice.Business
{
    public class UserBusinessLogic:IUserBusinessLogic
    {
        private readonly IUserRepository _userRepository;

        public UserBusinessLogic(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public async Task<string> Login(LoginDto loginDto)
        {
            await loginDto.ValidateAndThrow();
            return await _userRepository.Login(loginDto);
        }

        public async Task<bool> Register(RegisterDto registerDto)
        {
            await registerDto.ValidateAndThrow();
            var repositoryResultForRegister = await _userRepository.Register(registerDto);
            return repositoryResultForRegister;
        }
    }
}