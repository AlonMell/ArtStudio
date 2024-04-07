using ArtStudio.Core.Dto;
using ArtStudio.Core.Models;

namespace ArtStudio.Core.Services;

public interface IUserService
{
    Task<string> Register(RegisterUserRequest userRequest);
    Task<string> Login(LoginUserRequest loginRequest);
    Task Get();
}