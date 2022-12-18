using Application.Dto;
using Dumb.Application.Interfaces;
using Dumb.Domain.Entities;

namespace Dumb.Application.Services
{
    public class RandomDogService : IRequest
    {
        private readonly BaseService<DogEntity> _service;
        public RandomDogService()
        {
            _service = new BaseService<DogEntity>();
        }
        public BaseDto InitializeAndLoad()
        {
            var result = _service.InitializeAndLoad("https://dog.ceo/api/breeds/image/random", new DogEntity());

            return new BaseDto(result._StatusCode, result._Data == null ? new { Message = result._Message } : result._Data);
        }
    }
}
