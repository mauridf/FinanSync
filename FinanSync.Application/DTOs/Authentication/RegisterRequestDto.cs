namespace FinanSync.Application.DTOs.Authentication;

public sealed record RegisterRequestDto(
    string Name,
    string Email,
    string Phone,
    string Password,
    string ConfirmPassword);