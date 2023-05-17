using IdentityMicroservice.DataAccess.Entities;
using IdentityMicroservice.Domain.DTOs;
using IdentityMicroservice.Repository.Contracts;
using IdentityMicroservice.Services;
using Microsoft.AspNetCore.Identity;
namespace IdentityMicroservice.Repository
{
    public class UserRepository :IUserRepository
    {

        private readonly UserManager<User> _userManager;

        public UserRepository(UserManager<User> userManager)
        {
            _userManager = userManager;
        }
        public async Task<string> Login(LoginDto loginDto)
        {
            var existingUser = await GetUserByEmailAsync(loginDto.Email);
            if (existingUser is null)
            {
                throw new Exception("Invalid credentials!");
            }
            await CheckIfPwdsMatchesAsync(existingUser, loginDto.Password);
            var roles = await _userManager.GetRolesAsync(existingUser);
            var tokenAsString = JwtService.GenerateToken(existingUser,roles);
            return tokenAsString;
        }

        public async Task<bool> Register(RegisterDto registerDto)
        {
            var newUser = new User()
            {
                FirstName = registerDto.FirstName,
                LastName = registerDto.LastName,
                Email = registerDto.Email,
                EmailConfirmed = true,
                UserName = registerDto.Email
            };
            var addResult = await _userManager.CreateAsync(newUser, registerDto.Password);
            if (addResult.Errors.Count() != 0)
            {
                throw new Exception($"Account already exists!");
            }
            if (registerDto.IsAdmin)
                await _userManager.AddToRoleAsync(newUser, "Admin");
            return true;
        }
        private async Task<User?> GetUserByEmailAsync(string email)
        {
            var user = await _userManager.FindByEmailAsync(email);
            return user;
        }
        private async Task CheckIfPwdsMatchesAsync(User existingUser, string password)
        {
            var isValidPassword = await _userManager.CheckPasswordAsync(existingUser, password);
            if (!isValidPassword)
                throw new Exception("Invalid credentials!");
        }
    }
}