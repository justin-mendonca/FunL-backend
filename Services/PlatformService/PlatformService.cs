using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FunL_backend.Data;
using FunL_backend.Dtos.Title;
using FunL_backend.Models;
using Microsoft.EntityFrameworkCore;

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

        public async Task<ServiceResponse<List<Title>>> SavePlatformTitles(List<AddTitleDto> titleList)
        {
            var serviceResponse = new ServiceResponse<List<Title>>();

            try
            {
                var titles = new List<Title>();

                foreach (var titleDto in titleList)
                {
                    var existingTitle = _dbContext.Titles.FirstOrDefault(t => t.Name == titleDto.Title);
                    if (existingTitle != null)
                    {
                        continue;
                    }

                    var title = _mapper.Map<Title>(titleDto);

                    if (titleDto.Genres != null)
                    {
                        title.TitleGenres = new List<TitleGenre>();
                        foreach (var genreDto in titleDto.Genres)
                        {
                            var genre = await _dbContext.Genre.FirstOrDefaultAsync(g => g.Name == genreDto.Name);

                            // create a new genre if it doesn't exist
                            if (genre == null)
                            {
                                genre = new Genre { Name = genreDto.Name };
                                _dbContext.Genre.Add(genre);
                            }

                            title.TitleGenres.Add(new TitleGenre
                            {
                                Genre = genre
                            });
                        }
                    }

                    _dbContext.Titles.Add(title);
                    await _dbContext.SaveChangesAsync();

                    titles.Add(title);
                }

                serviceResponse.Data = titles;
                serviceResponse.Message = "Titles saved successfully";
            }
            catch (Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = "Failed to save titles: " + ex.Message;
            }

            return serviceResponse;
        }
    }
}