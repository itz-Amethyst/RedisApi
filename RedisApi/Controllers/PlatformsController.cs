﻿using Microsoft.AspNetCore.Mvc;
using RedisApiManagement.Application.Contracts.Platform;
using RedisApiManagement.Domain.Platform;

namespace RedisApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlatformsController : ControllerBase
    {
        private readonly IPlatformRepository _platformRepository;

        public PlatformsController(IPlatformRepository platformRepository)
        {
            _platformRepository = platformRepository;
        }

        [HttpGet("{id}" , Name = "GetPlatformById")]
        public ActionResult<PlatformViewModel> GetPlatformById(string id)
        {
            var platform = _platformRepository.GetPlatformById(id);

            if (platform != null)
            {
                return Ok(platform);
            }

            return NotFound();
        }

        [HttpPost]
        public ActionResult<PlatformViewModel> CreatePlatform(CreatePlatform command)
        {
            _platformRepository.CreatePlatform(command);

            return CreatedAtRoute(nameof(GetPlatformById), new { Id = command.Id }, command);
        }

        [HttpGet]
        public ActionResult<IEnumerable<PlatformViewModel>> GetAllPlatforms()
        {

            return Ok(_platformRepository.GetAllPlatforms());
        }
    }
}
