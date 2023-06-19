using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FunL_backend.Services.PlatformService
{
    public interface IPlatformService
    {
        Task<String> GetPlatformTitles();
        Task<List<Title>> SavePlatformTitles(List<Title> TitleList);
    }
}