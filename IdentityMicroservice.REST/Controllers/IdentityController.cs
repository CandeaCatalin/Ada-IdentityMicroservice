using IdentityMicroservice.Business.Contracts;
using IdentityMicroservice.Domain.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace IdentityMicroservice.REST.Controllers;

[ApiController]
[Route("api/auth")]
public class IdentityController : ControllerBase
{
    private readonly IUserBusinessLogic _userBusinessLogic;

    public IdentityController(IUserBusinessLogic userBusinessLogic)
    {
        _userBusinessLogic = userBusinessLogic;
    }
    [HttpPost("Login")]
    public async Task<IActionResult> Login(LoginDto loginDto)
    {
       
            var generatedToken = await _userBusinessLogic.Login(loginDto);
            return Ok(new {Token = generatedToken});
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register(RegisterDto registerDto)
    {
        await _userBusinessLogic.Register(registerDto);
        return Ok();
    }
    

    [HttpGet("checkSession")]
    [Authorize(Roles="Admin")]
    public IActionResult CheckSession()
    {
        return Ok();
    }
}