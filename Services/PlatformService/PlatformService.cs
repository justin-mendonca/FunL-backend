using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FunL_backend.Data;
using FunL_backend.Models;

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

        public async Task<ServiceResponse<List<Title>>> GetPlatformTitles()
        {
            // return list of titles here
            var serviceResponse = new ServiceResponse<List<Title>>();
            serviceResponse.Data = await _dbContext.Titles.ToListAsync();
            return serviceResponse;
        }

        public async Task<ServiceResponse<List<Title>>> SavePlatformTitles(AddTitleDto[] titleList)
        {
            var serviceResponse = new ServiceResponse<List<Title>>();

            try
            {
                // Create a new list to hold the mapped and saved Title objects
                var titles = new List<Title>();

                foreach (var title in titleList)
                {
                    // Check if Title already exists in db - if it does skip to next title
                    var duplicateTitle = _dbContext.Titles.FirstOrDefault(t => t.Name == title.Title);
                    if (duplicateTitle != null)
                    {
                        continue;
                    }

                    // Check if genres already exist in the database
                    var existingGenres = new List<Genre>();

                    foreach (var genre in title.Genres)
                    {
                        var existingGenre = _dbContext.Genre.FirstOrDefault(g => g.Name == genre.Name);
                        if (existingGenre != null)
                        {
                            existingGenres.Add(existingGenre);
                        }
                        else
                        {
                            // Genre doesn't exist, add it to the database
                            _dbContext.Genre.Add(genre);
                            existingGenres.Add(genre);
                        }
                    }

                    var titleEntity = _mapper.Map<Title>(title);

                    var streamingInfo = _mapper.Map<Dictionary<string, Dictionary<string, List<StreamingServiceInfo>>>>(title.StreamingInfo);
                    titleEntity.StreamingInfo = streamingInfo;

                    titleEntity.Genres = existingGenres;

                    // Save the Title object to the database
                    _dbContext.Titles.Add(titleEntity);
                    await _dbContext.SaveChangesAsync();

                    // Add the Title object to the list that will be returned to frontend
                    titles.Add(titleEntity);
                }
                serviceResponse.Data = titles;
                serviceResponse.Message = "Titles saved successfully";
            }
            catch (Exception ex)
            {
                // Handle any exceptions that occur during the saving process
                serviceResponse.Success = false;
                serviceResponse.Message = "Failed to save titles: " + ex.Message;
            }
            return serviceResponse;
        }
    }
}