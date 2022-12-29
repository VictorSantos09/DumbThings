using Application.Dto;
using Dumb.Application.Interfaces;
using Dumb.Domain.Entities;

namespace Dumb.Application.Services
{
    public class RandomDogService : IServiceRequest
    {
        private readonly IBaseRequest _service;
        public string URL { get; private set; } = "https://dog.ceo/api/breeds/image/random";
        public RandomDogService(IBaseRequest baseRequest)
        {
            _service = baseRequest;
        }
        public BaseDto InitializeAndLoad()
        {
            var result = _service.InitializeAndLoad(URL, new DogEntity());

            return new BaseDto(result._StatusCode, result._Data == null ? new { Message = result._Message } : result._Data);
        }
    }
}
