using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FunL_backend.Services.PlatformService
{
    public class PlatformService : IPlatformService
    {
        public async Task<String> GetPlatformTitles()
        {
            // return list of titles here
            return "your titles here";
        }

        public async Task<List<Title>> SavePlatformTitles(List<Title> TitleList)
        {
            // perform logic to save passed in title list to database

            // return complete list of titles for that service so far
            return "hello world";
        }
    }
}