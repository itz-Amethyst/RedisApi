namespace RedisApiManagement.Application.Contracts.Platform
{
    public class CreatePlatform
    {
        public string Id { get; set; } = $"Platform: {Guid.NewGuid().ToString()}";

        public string Name { get; set; }
    }
}
