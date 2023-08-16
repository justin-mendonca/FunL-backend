using FunL_backend.Dtos.Subscription;
using FunL_backend.Services.SubscriptionService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


namespace FunL_backend.Controllers
{
    [ApiController]
    [Route("subscriptions")]
    [Authorize]
    public class SubscriptionController : ControllerBase
    {
        private readonly ISubscriptionService _subscriptionService;

        public SubscriptionController(ISubscriptionService subscriptionService)
        {
            _subscriptionService = subscriptionService;
        }

        [HttpPost]
        public async Task<ActionResult<ServiceResponse<List<GetSubscriptionDto>>>> SaveSubscriptions(AddSubsriptionDto Subscriptions)
        {
            var serviceResponse = await _subscriptionService.SaveSubscriptions(Subscriptions);

            if (!serviceResponse.Success)
            {
                return BadRequest(serviceResponse);
            }

            return Ok(serviceResponse);
        }

        [HttpGet]
        public async Task<ActionResult<ServiceResponse<List<GetSubscriptionDto>>>> GetSubscriptions()
        {
            var serviceReponse = await _subscriptionService.GetSubscriptions();

            if (!serviceReponse.Success) 
            {
                return BadRequest(serviceReponse);
            }

            return Ok(serviceReponse);
        }
    }
}
