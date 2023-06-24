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

            //db.StringSet(command.Id, serialPlat);
            //db.SetAdd("PlatformSet", serialPlat);

            db.HashSet("HashPlatform", new HashEntry[]
            {
                new HashEntry(command.Id, serialPlat)
            });

        }

        public PlatformViewModel? GetPlatformById(string platformId)
        {
            var db = _redis.GetDatabase();

            //var plat = db.StringGet(platformId);

            var plat = db.HashGet("HashPlatform" , platformId);


            if (!string.IsNullOrEmpty(plat))
            {
                return JsonSerializer.Deserialize<PlatformViewModel>(plat);
            }

            return null;
        }

        public IEnumerable<PlatformViewModel>? GetAllPlatforms()
        {
            var db = _redis.GetDatabase();

            //var completeSet = db.SetMembers("PlatformSet");

            var completeHash = db.HashGetAll("HashPlatform");


            if (completeHash.Length > 0)
            {
                var obj = Array.ConvertAll(completeHash, val => JsonSerializer.Deserialize<PlatformViewModel>(val.Value))
                    .ToList();

                return obj;
            }

            return null;
        }
    }
}
