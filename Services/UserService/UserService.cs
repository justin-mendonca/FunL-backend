using FunL_backend.Dtos.NewFolder;
using Microsoft.AspNetCore.Identity;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using System.Text;
using Microsoft.Extensions.Options;

namespace FunL_backend.Services.UserService
{
    public class UserService : IUserService
    {
        private readonly DataContext _dbContext;
        private readonly IMapper _mapper;
        private readonly PasswordHasher<User> _passwordHasher;
        private readonly JwtSettings _jwtSettings;

        public UserService(
            DataContext dbContext,
            IMapper mapper,
            IOptions<JwtSettings> jwtSettings
            )
        {
            _dbContext = dbContext;
            _mapper = mapper;
            _passwordHasher = new PasswordHasher<User>();
            _jwtSettings = jwtSettings.Value;
        }

        public async Task<ServiceResponse<string>> RegisterUser (RegisterUserDto userData)
        {
            var serviceResponse = new ServiceResponse<string>();
            var user = _mapper.Map<User>(userData);

            try
            {
                var existingUser = await _dbContext.Users
                    .FirstOrDefaultAsync(x => x.Email == userData.Email);

                if (existingUser != null)
                {
                    serviceResponse.Success = false;
                    serviceResponse.Data = "Unsuccessful registration. Please try again with a different email";
                    return serviceResponse;
                }

                user.Password = _passwordHasher.HashPassword(user, userData.Password);
                _dbContext.Users.Add(user);
                await _dbContext.SaveChangesAsync();
                serviceResponse.Success = true;
            }
            catch (Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = "Failed to save user: " + ex.Message;
            }

            if ( serviceResponse.Success )
            {
                serviceResponse.Token = GenerateJwtToken(user);
                serviceResponse.Data = "Successfully registered and JWT token generated!";
            }
            return serviceResponse;
        }

        public bool VerifyPassword(User user, string providedPassword)
        {
            var result = _passwordHasher.VerifyHashedPassword(user, user.Password, providedPassword);
            return result == PasswordVerificationResult.Success;
        }

        public string GenerateJwtToken(User user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_jwtSettings.Key);  // Assuming you injected your Jwt settings from appsettings.json
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
            new Claim(ClaimTypes.Name, user.Email)  // or user.Id.ToString() if you want to store the user ID in the token
        }),
                Expires = DateTime.UtcNow.AddDays(7),  // token expiry, adjust as needed
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature),
                Issuer = _jwtSettings.Issuer
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}
