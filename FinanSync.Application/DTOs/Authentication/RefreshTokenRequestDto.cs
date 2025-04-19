namespace FinanSync.Core.DTOs.Authentication;

public sealed record RefreshTokenRequestDto(
    string Token,
    string RefreshToken);