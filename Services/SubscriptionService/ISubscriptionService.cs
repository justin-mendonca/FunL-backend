using FunL_backend.Dtos.Subscription;

namespace FunL_backend.Services.SubscriptionService
{
    public interface ISubscriptionService
    {
        Task<ServiceResponse<List<GetSubscriptionDto>>> SaveSubscriptions(AddSubsriptionDto Subscriptions);
    }
}
