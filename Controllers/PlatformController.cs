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
        public async Task<ActionResult<List<Title>>> GetPlatformTitles()
        {
            return Ok(await _platformService.GetPlatformTitles());
        }

        [HttpPost]
        public async Task<ActionResult<List<Title>>> SavePlatformTitles(List<Title> TitleList)
        {
            return Ok(await _platformService.SavePlatformTitles(TitleList));
        } 
    }
}