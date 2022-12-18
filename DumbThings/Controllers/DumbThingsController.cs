using Dumb.Application.Dto;
using Dumb.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace DumbThings.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DumbThingsController : ControllerBase
    {

        private readonly JokeService _jokeService;
        private readonly CatFactService _catFactService;
        private readonly RandomDogService _randomDogService;
        private readonly BoredService _boredService;
        private readonly NameAndGenderService _nameAndGenderService;

        public DumbThingsController(JokeService jokeService, CatFactService catFactService, RandomDogService randomDogService,
            BoredService boredService, NameAndGenderService nameAndGenderService)
        {
            _jokeService = jokeService;
            _catFactService = catFactService;
            _randomDogService = randomDogService;
            _boredService = boredService;
            _nameAndGenderService = nameAndGenderService;
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

        [HttpGet]
        [Route("GetCatFacts")]
        public IActionResult GetCatFacts()
        {
            var result = _catFactService.InitializeAndLoad();

            return StatusCode(result._StatusCode, result._Data == null ? new { Message = result._Message } : result._Data);
        }
        [HttpGet]
        [Route("GetRandomDog")]
        public IActionResult GetRandomDog()
        {
            var result = _randomDogService.InitializeAndLoad();

            return StatusCode(result._StatusCode, result._Data == null ? new { Message = result._Message } : result._Data);
        }
        [HttpGet]
        [Route("GetBoredActivity")]
        public IActionResult GetActivity()
        {
            var result = _boredService.InitializeAndLoad();

            return StatusCode(result._StatusCode, result._Data == null ? new { Message = result._Message } : result._Data);
        }

        [HttpPost]
        [Route("GetGenderAndName")]
        public IActionResult GetGenderAndName(UserToSupposeDto supposeDto)
        {
            var result = _nameAndGenderService.InitializeAndLoad(supposeDto.Name);

            return StatusCode(result._StatusCode, result._Data == null ? new { Message = result._Message } : result._Data);
        }
    }
}