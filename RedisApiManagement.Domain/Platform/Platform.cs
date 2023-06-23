using System.ComponentModel.DataAnnotations;
using Guid = System.Guid;

namespace RedisApiManagement.Domain.Platform
{
    public class Platform
    {
        [Required]
        public string Id { get; private set; }

        [Required]
        public string Name { get; private set; }

        public Platform(string name)
        {
            Id = $"Platform: {Guid.NewGuid().ToString()}";
            Name = name;
        }
    }
}
