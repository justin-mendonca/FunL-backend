using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FunL_backend.Services.PlatformService
{
    public class PlatformService : IPlatformService
    {
        public async Task<ServiceResponse<String>> GetPlatformTitles()
        {
            // return list of titles here
            var serviceResponse = new ServiceResponse<String>();
            serviceResponse.Data = "your response here";
            return serviceResponse;
        }

        public async Task<ServiceResponse<List<Title>>> SavePlatformTitles(List<Title> TitleList)
        {
            // perform logic to save passed in title list to database

            // return complete list of titles for that service so far

            var serviceResponse = new ServiceResponse<List<Title>>();
            serviceResponse.Data = TitleList;
            return serviceResponse;
        }
    }
}