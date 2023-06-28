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

        [HttpGet]
        public async Task<ActionResult<ServiceResponse<List<Title>>>> GetPlatformTitles()
        {
            return Ok(await _platformService.GetPlatformTitles());
        }

        // make sure to change GetTitleDto that is taken in as an argument to AddTitleDto and change throughout the route
        [HttpPost]
        public async Task<ActionResult<ServiceResponse<List<Title>>>> SavePlatformTitles(List<AddTitleDto> titleList)
        {
            return Ok(await _platformService.SavePlatformTitles(titleList));
        } 
    }
}