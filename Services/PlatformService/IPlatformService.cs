using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FunL_backend.Services.PlatformService
{
    public interface IPlatformService
    {
        Task<ServiceResponse<String>> GetPlatformTitles();
        Task<ServiceResponse<List<GetTitleDto>>> SavePlatformTitles(List<GetTitleDto> TitleList);
    }
}