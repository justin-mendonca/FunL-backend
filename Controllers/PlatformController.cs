using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace FunL_backend.Controllers
{
    [ApiController]
    [Route("platform")]
    public class PlatformController : ControllerBase
    {
        private readonly IPlatformService _platformService;

        public PlatformController(IPlatformService platformService)
        {
            _platformService = platformService;
        }

        [HttpPost("GetTitles")]
        public async Task<ActionResult<ServiceResponse<List<GetTitleDto>>>> GetTitlesBySubscribedPlatforms([FromBody] string[] subscribedPlatforms)
        {
            return Ok(await _platformService.GetTitlesBySubscribedPlatforms(subscribedPlatforms));
        }

        [HttpPost]
        public async Task<ActionResult<ServiceResponse<List<Title>>>> SavePlatformTitles(List<AddTitleDto> titleList)
        {
            return Ok(await _platformService.SavePlatformTitles(titleList));
        } 
    }
}