using Application.DTOs;
using SCleanArchitecture.SimpleAPI.Application.Converters;
using SCleanArchitecture.SimpleAPI.Application.DTOs;
using SCleanArchitecture.SimpleAPI.Domain.Repositories;

namespace SCleanArchitecture.SimpleAPI.Application.Services
{
    public interface IUserService
    {
        Task<AddUserResponseDto> AddUser(AddUserRequestDto requestDto);
        Task<DeleteUserResponseDto> DeleteUserAsync(DeleteUserRequestDto dto);
        Task<IEnumerable<UserResponseDto>> GetAllUsersAsync();
        Task<UserResponseDto?> GetUserByIdAsync(int id);
        Task<UpdateUserResponseDto> UpdateUserAsync(UpdateUserRequestDto dto);
    }

    internal sealed class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<AddUserResponseDto> AddUser(AddUserRequestDto requestDto)
        {
            if (!requestDto.IsValid())
                return UserErrors.InvalidRequest();

            var userEntity = requestDto.ToUserEntity();
            await _userRepository.AddUserAsync(userEntity);

            return requestDto.ToAddUserResponse(userEntity.CreatedAt);
        }

        public async Task<DeleteUserResponseDto> DeleteUserAsync(DeleteUserRequestDto dto)
        {
            if (!dto.IsValid())
                return new DeleteUserResponseDto { Success = false, Message = "Invalid request." };

            var existingUser = await _userRepository.GetUserByIdAsync(dto.Id);
            if (existingUser == null)
                return new DeleteUserResponseDto { Success = false, Message = "User not found." };

            await _userRepository.DeleteUserAsync(dto.Id);
            return new DeleteUserResponseDto { Success = true, Message = "User deleted successfully." };
        }

        public async Task<IEnumerable<UserResponseDto>> GetAllUsersAsync()
        {
            var users = await _userRepository.GetAllUsersAsync();
            return users.Select(u => new UserResponseDto
            {
                Id = u.Id,
                Name = u.Name,
                Email = u.Email
            });
        }

        public async Task<UserResponseDto?> GetUserByIdAsync(int id)
        {
            var user = await _userRepository.GetUserByIdAsync(id);
            if (user == null) return null;

            return new UserResponseDto
            {
                Id = user.Id,
                Name = user.Name,
                Email = user.Email
            };
        }

        public async Task<UpdateUserResponseDto> UpdateUserAsync(UpdateUserRequestDto dto)
        {
            if (!dto.IsValid())
                return new UpdateUserResponseDto { Success = false, Message = "Invalid request." };

            var existingUser = await _userRepository.GetUserByIdAsync(dto.Id);
            if (existingUser == null)
                return new UpdateUserResponseDto { Success = false, Message = "User not found." };

            existingUser.Name = dto.Name;
            existingUser.Email = dto.Email;

            await _userRepository.UpdateUserAsync(existingUser);

            return new UpdateUserResponseDto { Success = true, Message = "User updated successfully." };
        }
    }

    public static class UserErrors
    {
        public static AddUserResponseDto InvalidRequest()
        {
            return new AddUserResponseDto();
        }
    }
}
