using FunL_backend.Dtos.User;

namespace FunL_backend.Services.UserService
{
    public interface IUserService
    {
        Task<ServiceResponse<string>> RegisterUser(RegisterUserDto userData);

        Task<ServiceResponse<string>> LoginUser(LoginUserDto userData);
    }
}
