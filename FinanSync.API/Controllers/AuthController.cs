using System.Security.Claims;
using FinanSync.Application.DTOs.Authentication;
using FinanSync.Core.DTOs.Authentication;
using FinanSync.Core.Interfaces.Services;
using FinanSync.Infrastructure.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FinanSync.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AuthController : ControllerBase
{
    private readonly IAuthService _authService;

    public AuthController(IAuthService authService)
    {
        _authService = authService;
    }

    [HttpPost("register")]
    [AllowAnonymous]
    public async Task<IActionResult> Register(RegisterRequestDto request)
    {
        var response = await _authService.RegisterAsync(request);
        return Ok(response);
    }

    [HttpPost("login")]
    [AllowAnonymous]
    public async Task<IActionResult> Login(LoginRequestDto request)
    {
        var response = await _authService.LoginAsync(request);
        return Ok(response);
    }

    [HttpPost("refresh-token")]
    [AllowAnonymous]
    public async Task<IActionResult> RefreshToken(
        [FromBody] RefreshTokenRequestDto request)
    {
        var response = await _authService.RefreshTokenAsync(
            request.Token,
            request.RefreshToken);
        return Ok(response);
    }

    [HttpPost("revoke-token")]
    [Authorize]
    public async Task<IActionResult> RevokeToken()
    {
        var userId = User.FindFirstValue(ClaimTypes.NameIdentifier)!;
        await _authService.RevokeTokenAsync(userId);
        return NoContent();
    }
}