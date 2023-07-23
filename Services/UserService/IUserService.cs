using FunL_backend.Dtos.NewFolder;

namespace FunL_backend.Services.UserService
{
    public interface IUserService
    {
        Task<ServiceResponse<string>> RegisterUser(RegisterUserDto userData);
    }
}
