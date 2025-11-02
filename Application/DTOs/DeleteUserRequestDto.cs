using System;

namespace SCleanArchitecture.SimpleAPI.Application.DTOs;

public sealed class DeleteUserRequestDto
{
    public int Id { get; set; }

    public bool IsValid()
    {
        return Id != null;
    }
}