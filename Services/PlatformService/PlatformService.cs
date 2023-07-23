using FunL_backend.Helpers;

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

        public async Task<ServiceResponse<List<GetTitleDto>>> GetTitlesBySubscribedPlatforms(string[] subscribedPlatforms)
        {
            var serviceResponse = new ServiceResponse<List<GetTitleDto>>();

            try
            {
                // Fetch the ids of the streaming platforms that correspond to the list of names passed in
                var platformIds = _dbContext.StreamingPlatforms
                    .Where(sp => subscribedPlatforms.Contains(sp.Name))
                    .Select(sp => sp.Id)
                    .ToList();

                var titles = await _dbContext.Titles
                    .Include(t => t.StreamingServices)
                        .ThenInclude(ss => ss.StreamingPlatform)
                    .Include(t => t.TitleGenres)
                        .ThenInclude(tg => tg.Genre)
                    .Where(t => t.StreamingServices.Any(ss => platformIds.Contains(ss.StreamingPlatformId)))
                    .ToListAsync();

                var getTitleDtos = _mapper.Map<List<GetTitleDto>>(titles);

                serviceResponse.Data = getTitleDtos;
            }
            catch (Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = "Failed to fetch titles: " + ex.Message;
            }

            return serviceResponse;
        }

        public async Task<ServiceResponse<List<GetTitleDto>>> SavePlatformTitles(List<AddTitleDto> titleList)
        {
            var serviceResponse = new ServiceResponse<List<GetTitleDto>>();

            try
            {
                var titles = new List<Title>();
                var existingGenres = _dbContext.Genres
                    .GroupBy(g => g.Name)
                    .Select(grp => grp.First())
                    .ToDictionary(g => g.Name, g => g);

                foreach (var titleDto in titleList)
                {
                    var existingTitle = _dbContext.Titles
                        .Include(t => t.StreamingServices)
                        .FirstOrDefault(t => t.Name == titleDto.Title);

                    if (existingTitle != null)
                    {
                        foreach (var streamingServiceInfoDto in titleDto.StreamingInfo)
                        {
                            var platformId = await GetOrCreatePlatformIdByNameAsync(streamingServiceInfoDto.Platform);
                            var alreadyExists = existingTitle.StreamingServices.Any(ss => ss.StreamingPlatformId == platformId);

                            if (!alreadyExists)
                            {
                                var serviceInfo = _mapper.Map<StreamingServiceInfo>(streamingServiceInfoDto);
                                serviceInfo.StreamingPlatformId = platformId;
                                serviceInfo.Audios = JsonHelper.Serialize(streamingServiceInfoDto.Audios);
                                serviceInfo.Subtitles = JsonHelper.Serialize(streamingServiceInfoDto.Subtitles);

                                existingTitle.StreamingServices.Add(serviceInfo);
                            }
                        }
                    }
                    else
                    {
                        var title = _mapper.Map<Title>(titleDto);
                        title.StreamingServices = new List<StreamingServiceInfo>();
                        title.TitleGenres = new List<TitleGenre>();

                        foreach (var genreName in titleDto.Genres)
                        {
                            Genre genre;

                            if (existingGenres.ContainsKey(genreName.Name))
                            {
                                genre = existingGenres[genreName.Name];
                            }
                            else
                            {
                                genre = new Genre { Name = genreName.Name };
                                existingGenres[genreName.Name] = genre;
                            }

                            title.TitleGenres.Add(new TitleGenre { Title = title, Genre = genre });
                        }

                        foreach (var streamingServiceInfoDto in titleDto.StreamingInfo)
                        {
                            var serviceInfo = _mapper.Map<StreamingServiceInfo>(streamingServiceInfoDto);
                            serviceInfo.StreamingPlatformId = await GetOrCreatePlatformIdByNameAsync(streamingServiceInfoDto.Platform);
                            serviceInfo.Audios = JsonHelper.Serialize(streamingServiceInfoDto.Audios);
                            serviceInfo.Subtitles = JsonHelper.Serialize(streamingServiceInfoDto.Subtitles);

                            title.StreamingServices.Add(serviceInfo);
                        }

                        _dbContext.Titles.Add(title);
                        titles.Add(title);
                    }
                }

                await _dbContext.SaveChangesAsync();

                var getTitleDtos = _mapper.Map<List<GetTitleDto>>(titles);
                serviceResponse.Data = getTitleDtos;
                serviceResponse.Message = "Titles saved successfully";
            }
            catch (Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = "Failed to save titles: " + ex.Message;
            }

            return serviceResponse;
        }


        public async Task<int> GetOrCreatePlatformIdByNameAsync(string platformName)
        {
            var platform = await _dbContext.StreamingPlatforms
                .FirstOrDefaultAsync(p => p.Name == platformName);

            if (platform == null)
            {
                platform = new StreamingPlatform
                {
                    Name = platformName
                };
                _dbContext.StreamingPlatforms.Add(platform);
                await _dbContext.SaveChangesAsync();
            }

            return platform.Id;
        }
    }
}