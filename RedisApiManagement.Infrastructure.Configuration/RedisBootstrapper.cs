using Microsoft.Extensions.DependencyInjection;
using StackExchange.Redis;

namespace RedisApiManagement.Infrastructure.Configuration
{
    public class RedisBootstrapper
    {
        public static void Configure(IServiceCollection services, string connectionString)
        {
            services.AddSingleton<IConnectionMultiplexer>(option =>
                ConnectionMultiplexer.Connect(connectionString));
        }
    }
}