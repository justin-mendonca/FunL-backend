using FunL_backend.Dtos.NewFolder;
using FunL_backend.Models;

namespace FunL_backend.Services.UserService
{
    public class UserService : IUserService
    {
        private readonly DataContext _dbContext;

        public UserService(DataContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<ServiceResponse<string>> RegisterUser (RegisterUserDto userData)
        {
            var serviceResponse = new ServiceResponse<string>();

            try
            {
                await _dbContext.SaveChangesAsync();
                serviceResponse.Success = true;
                serviceResponse.Data = "Success!";
            }
            catch (Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = "Failed to save user: " + ex.Message;
            }

            return serviceResponse;
        }
    }
}
