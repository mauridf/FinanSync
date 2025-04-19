namespace FinanSync.Application.DTOs.Authentication;

public sealed record LoginRequestDto(
    string Email,
    string Password);