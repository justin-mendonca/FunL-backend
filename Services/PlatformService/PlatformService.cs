using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FunL_backend.Services.PlatformService
{
    public class PlatformService : IPlatformService
    {
        private readonly IMapper _mapper;

        public PlatformService(IMapper mapper)
        {
            _mapper = mapper;
        }

        public async Task<ServiceResponse<String>> GetPlatformTitles()
        {
            // return list of titles here
            var serviceResponse = new ServiceResponse<String>();
            serviceResponse.Data = "your response here";
            return serviceResponse;
        }

        public async Task<ServiceResponse<List<GetTitleDto>>> SavePlatformTitles(List<GetTitleDto> TitleList)
        {
            // perform logic to save passed in title list to database

            // return complete list of titles for that service so far

            var serviceResponse = new ServiceResponse<List<GetTitleDto>>();
            serviceResponse.Data = TitleList;
            return serviceResponse;
        }
    }
}