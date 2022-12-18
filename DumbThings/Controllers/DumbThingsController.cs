using Application.Dto;
using Dumb.Application.Services;
using Dumb.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace DumbThings.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DumbThingsController : ControllerBase
    {

        private readonly JokeService _jokeService;

        public DumbThingsController(JokeService jokeService)
        {
            _jokeService = jokeService;
        }

        [HttpGet]
        [Route("GetAllDumbThings")]
        public void GetAll()
        {

        }
        [HttpGet]
        [Route("GetJoke")]
        public IActionResult GetJoke()
        {
            var result = _jokeService.InitializeAndLoad();

            return StatusCode(result._StatusCode, result._Data == null ? new { Message = result._Message } : result._Data);
        }
    }
}