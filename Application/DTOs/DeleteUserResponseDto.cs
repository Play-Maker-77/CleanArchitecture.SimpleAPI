namespace SCleanArchitecture.SimpleAPI.Application.DTOs;

public sealed class DeleteUserResponseDto
{
    public bool Success { get; set; }
    public string ?Message { get; set; }
}
