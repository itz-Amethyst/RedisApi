using RedisApiManagement.Application.Contracts.Platform;

namespace RedisApiManagement.Domain.Platform
{
    public interface IPlatformRepository
    {
        // Can Create A base generic repository for common methods but because its small not necessary

        void CreatePlatform(CreatePlatform command);

        PlatformViewModel? GetPlatformById(string platformId);

        IEnumerable<PlatformViewModel>? GetAllPlatforms();
    }
}
