using FunL_backend.Dtos.Subscription;
using System.Security.Claims;

namespace FunL_backend.Services.SubscriptionService
{
    public class SubscriptionService : ISubscriptionService
    {
        private readonly IMapper _mapper;
        private readonly DataContext _dbContext;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public SubscriptionService(
        IMapper mapper,
        DataContext dbContext,
        IHttpContextAccessor httpContextAccessor
        )
        {
            _mapper = mapper;
            _dbContext = dbContext;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<ServiceResponse<List<GetSubscriptionDto>>> SaveSubscriptions(AddSubsriptionDto Subscriptions)
        {
            var serviceResponse = new ServiceResponse<List<GetSubscriptionDto>>();

            try
            {
                var userEmailClaim = _httpContextAccessor.HttpContext?.User.FindFirst(ClaimTypes.Name);

                if (userEmailClaim == null)
                {
                    serviceResponse.Success = false;
                    serviceResponse.Message = "User email claim not found in the HttpContext.";
                    return serviceResponse;
                }

                var userEmail = userEmailClaim.Value;

                var user = await _dbContext.Users.FirstOrDefaultAsync(x => x.Email == userEmail);

                if (user == null)
                {
                    serviceResponse.Success = false;
                    serviceResponse.Message = "User not found for the provided email.";
                    return serviceResponse;
                }

                var existingSubscriptions = await _dbContext.UserStreamingPlatforms
                    .Where(x => x.UserId == user.Id)
                    .ToListAsync();

                foreach (var existingSubscription in existingSubscriptions)
                {
                    _dbContext.UserStreamingPlatforms.Remove(existingSubscription);
                }

                await _dbContext.SaveChangesAsync();

                user.UserStreamingPlatforms ??= new List<UserStreamingPlatform>();

                foreach (var property in Subscriptions.GetType().GetProperties())
                {
                    var platformName = property.Name;
                    var propertyValue = property.GetValue(Subscriptions);

                    if (propertyValue is bool isSubscribed && isSubscribed)
                    {
                        var streamingPlatform = await _dbContext.StreamingPlatforms.FirstOrDefaultAsync(x => x.Name == platformName.ToLower());

                        if (streamingPlatform != null)
                        {
                            user.UserStreamingPlatforms.Add(new UserStreamingPlatform
                            {
                                UserId = user.Id,
                                StreamingPlatformId = streamingPlatform.Id,
                            });

                            var subscriptionDto = new GetSubscriptionDto
                            {
                                StreamingPlatformId = streamingPlatform.Id,
                                StreamingPlatformName = streamingPlatform.Name,
                            };

                            serviceResponse.Data ??= new List<GetSubscriptionDto>();
                            serviceResponse.Data.Add(subscriptionDto);
                        }
                    }
                }

                await _dbContext.SaveChangesAsync();

                serviceResponse.Success = true;
                serviceResponse.Message = "Subscriptions saved successfully";
            }
            catch (Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = $"An error occurred while saving subscriptions: {ex.Message}";
            }

            return serviceResponse;
        }
    }
}
