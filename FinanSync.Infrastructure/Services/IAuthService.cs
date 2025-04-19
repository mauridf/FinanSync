using FinanSync.Application.DTOs.Authentication;

namespace FinanSync.Core.Interfaces.Services;

public interface IAuthService
{
    Task<AuthResponseDto> RegisterAsync(RegisterRequestDto request);
    Task<AuthResponseDto> LoginAsync(LoginRequestDto request);
    Task<AuthResponseDto> RefreshTokenAsync(string token, string refreshToken);
    Task RevokeTokenAsync(string userId);
}