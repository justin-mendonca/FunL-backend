using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FunL_backend.Data;

namespace FunL_backend.Services.PlatformService
{
    public class PlatformService : IPlatformService
    {
        private readonly IMapper _mapper;
        private readonly DataContext _dbContext;

        public PlatformService(
            IMapper mapper,
            DataContext dbContext
            )
        {
            _mapper = mapper;
            _dbContext = dbContext;
        }

        public async Task<ServiceResponse<String>> GetPlatformTitles()
        {
            // return list of titles here
            var serviceResponse = new ServiceResponse<String>();
            serviceResponse.Data = "your response here";
            return serviceResponse;
        }

        public async Task<ServiceResponse<List<GetTitleDto>>> SavePlatformTitles(Title[] titleList)
        {
            var serviceResponse = new ServiceResponse<List<GetTitleDto>>();

            try
            {
                // Create a new list to hold the GetTitleDto objects
                var getTitleDtoList = new List<GetTitleDto>();

                // Iterate over each Title object in the titleList
                foreach (var title in titleList)
                {
                    // Save the Title object to the database using your database context
                    _dbContext.Titles.Add(title);
                    await _dbContext.SaveChangesAsync();

                    // Create a GetTitleDto object from the saved Title object
                    var getTitleDto = new GetTitleDto
                    {
                        // Map the properties from the saved Title object to the GetTitleDto object
                        // Adjust the mapping according to your class structure and properties
                        Id = title.Id,
                        Name = title.Name,
                        // Include other properties as needed
                    };

                    // Add the GetTitleDto object to the list
                    getTitleDtoList.Add(getTitleDto);
                }

                // Set the data property of the service response to the list of GetTitleDto objects
                serviceResponse.Data = getTitleDtoList;
                serviceResponse.Message = "Titles saved successfully";
            }
            catch (Exception ex)
            {
                // Handle any exceptions that occur during the saving process
                serviceResponse.Success = false;
                serviceResponse.Message = "Failed to save titles: " + ex.Message;
                // You can log the exception for further analysis if needed
            }

            return serviceResponse;
        }
    }
}