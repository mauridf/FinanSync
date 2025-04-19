namespace FinanSync.Application.DTOs.Authentication;

public sealed record AuthResponseDto(
    string Token,
    DateTime Expiration,
    string RefreshToken,
    DateTime RefreshTokenExpiry,
    string UserId,
    string Email,
    string Name);