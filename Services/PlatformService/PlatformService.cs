using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
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

        public async Task<ServiceResponse<List<Title>>> GetPlatformTitles(string country, string service)
        {
            var serviceResponse = new ServiceResponse<List<Title>>();

            try
            {
                var titles = await _dbContext.Titles
                    .FromSqlRaw($"SELECT * FROM [master].[dbo].[Titles] WHERE JSON_QUERY(StreamingInfo, '$.{country}.{service}') IS NOT NULL;")
                    .ToListAsync();

                serviceResponse.Data = titles;
            }
            catch (Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = "Failed to fetch titles: " + ex.Message;
            }

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
                        // If title already exists, just update the StreamingServices list with the new platform service info
                        foreach (var streamingServiceInfoDto in titleDto.StreamingInfo)
                        {
                            var streamingServiceInfo = _mapper.Map<StreamingServiceInfo>(streamingServiceInfoDto);
                            streamingServiceInfo.StreamingPlatformId = await GetOrCreatePlatformIdByNameAsync(streamingServiceInfoDto.Platform);
                            existingTitle.StreamingServices.Add(streamingServiceInfo);
                        }
                    }
                    else
                    {
                        var title = _mapper.Map<Title>(titleDto);
                        title.StreamingServices = new List<StreamingServiceInfo>();

                        foreach (var streamingServiceInfoDto in titleDto.StreamingInfo)
                        {
                            var serviceInfo = _mapper.Map<StreamingServiceInfo>(streamingServiceInfoDto);
                            serviceInfo.StreamingPlatformId = await GetOrCreatePlatformIdByNameAsync(streamingServiceInfoDto.Platform);
                            title.StreamingServices.Add(serviceInfo);
                        }

                        _dbContext.Titles.Add(title);
                        titles.Add(title);
                    }
                }

                await _dbContext.SaveChangesAsync();

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