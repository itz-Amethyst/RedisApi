using System.ComponentModel.DataAnnotations;
using Guid = System.Guid;

namespace RedisApiManagement.Domain.Platform
{
    public class Platform
    {
        [Required]
        public string Id { get; private set; } = $"Platform: {Guid.NewGuid().ToString()}";

        [Required] public string Name { get; private set; } = string.Empty;
    }
}
