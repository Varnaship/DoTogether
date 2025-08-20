using DoTogetherDatabase.Common.DTOs;

namespace DoTogetherDatabase.Services.Interfaces
{
    public interface IUserService
    {
        Task<AuthResponseDto?> RegisterAsync(UserRegisterDto dto);
        Task<AuthResponseDto?> LoginAsync(UserLoginDto dto);
    }
}