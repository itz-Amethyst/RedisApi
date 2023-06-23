using System.Text.Json;
using RedisApiManagement.Application.Contracts.Platform;
using RedisApiManagement.Domain.Platform;
using StackExchange.Redis;

namespace RedisApiManagement.Infrastructure.Repository
{
    public class PlatformRepository : IPlatformRepository
    {
        private readonly IConnectionMultiplexer _redis;

        public PlatformRepository(IConnectionMultiplexer redis)
        {
            _redis = redis;
        }

        public void CreatePlatform(CreatePlatform command)
        {
            if (command == null)
            {
                throw new ArgumentException(nameof(command));
            }

            var db = _redis.GetDatabase();

            var serialPlat = JsonSerializer.Serialize(command);

            db.StringSet(command.Id, serialPlat);

        }

        public PlatformViewModel? GetPlatformById(string platformId)
        {
            var db = _redis.GetDatabase();

            var plat = db.StringGet(platformId);

            if (!string.IsNullOrEmpty(plat))
            {
                return JsonSerializer.Deserialize<PlatformViewModel>(plat);
            }

            return null;
        }

        public IEnumerable<PlatformViewModel> GetAllPlatforms()
        {
            throw new NotImplementedException();
        }
    }
}
