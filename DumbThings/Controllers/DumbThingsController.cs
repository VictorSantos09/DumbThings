using Dumb.Application.Dto;
using Dumb.Application.Interfaces;
using Dumb.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace DumbThings.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DumbThingsController : ControllerBase
    {
        private readonly IServiceRequest _Joke;
        private readonly IServiceRequest _CatFacts;
        private readonly IServiceRequest _Bored;
        private readonly IServiceRequest _RickAndMorty;
        private readonly IServiceRequest _RandomDog;
        private readonly ISupposeNameGenderAge _NameAndGender;

        public DumbThingsController(BaseService baseService)
        {
            _Joke = new JokeService(baseService);
            _CatFacts = new CatFactService(baseService);
            _Bored = new BoredService(baseService);
            _NameAndGender = new NameAndGenderService(baseService);
            _RickAndMorty = new RickAndMortyService(baseService);
            _RandomDog = new RandomDogService(baseService);
        }

        [HttpGet]
        [Route("GetJoke")]
        public IActionResult GetJoke()
        {
            var result = _Joke.InitializeAndLoad();

            return StatusCode(result._StatusCode, result._Data == null ? new { Message = result._Message } : result._Data);
        }

        [HttpGet]
        [Route("GetCatFacts")]
        public IActionResult GetCatFacts()
        {
            var result = _CatFacts.InitializeAndLoad();

            return StatusCode(result._StatusCode, result._Data == null ? new { Message = result._Message } : result._Data);
        }
        [HttpGet]
        [Route("GetRandomDog")]
        public IActionResult GetRandomDog()
        {
            var result = _RandomDog.InitializeAndLoad();

            return StatusCode(result._StatusCode, result._Data == null ? new { Message = result._Message } : result._Data);
        }
        [HttpGet]
        [Route("GetBoredActivity")]
        public IActionResult GetActivity()
        {
            var result = _Bored.InitializeAndLoad();

            return StatusCode(result._StatusCode, result._Data == null ? new { Message = result._Message } : result._Data);
        }

        [HttpPost]
        [Route("GetGenderAndAge")]
        public IActionResult GetGenderAge(UserToSupposeDto supposeDto)
        {
            var result = _NameAndGender.InitializeAndLoad(supposeDto.Name);

            return StatusCode(result._StatusCode, result._Data == null ? new { Message = result._Message } : result._Data);
        }
        [HttpPost]
        [Route("GetRickAndMorty")]
        public IActionResult GetRickAndMorty()
        {
            var result = _RickAndMorty.InitializeAndLoad();

            return StatusCode(result._StatusCode, result._Data);
        }
    }
}