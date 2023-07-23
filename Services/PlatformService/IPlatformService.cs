namespace FunL_backend.Services.PlatformService
{
    public interface IPlatformService
    {
        Task<ServiceResponse<List<GetTitleDto>>> GetTitlesBySubscribedPlatforms(string[] subscribedPlatforms);
        Task<ServiceResponse<List<GetTitleDto>>> SavePlatformTitles(List<AddTitleDto> titleList);
        Task<int> GetOrCreatePlatformIdByNameAsync(string platformName);
    }
}