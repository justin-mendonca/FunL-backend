using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FunL_backend.Services.PlatformService
{
    public interface IPlatformService
    {
        Task<ServiceResponse<List<GetTitleDto>>> GetTitlesBySubscribedPlatforms(string[] subscribedPlatforms);
        Task<ServiceResponse<List<Title>>> SavePlatformTitles(List<AddTitleDto> titleList);
        Task<int> GetOrCreatePlatformIdByNameAsync(string platformName);
    }
}