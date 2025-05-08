using CollabBoard.Api.DTOs;

namespace CollabBoard.Api.Services
{
    public interface IAuthService
    {
        Task<UserDto?> Register(UserRegisterDto userRegisterDto);
        Task<UserDto?> Login(UserLoginDto userLoginDto);
    }
}