using Application.Dto;
using Dumb.Application.Interfaces;
using Dumb.Domain.Entities;

namespace Dumb.Application.Services
{
    public class JokeService : IServiceRequest
    {
        private readonly IBaseRequest _service;
        public string URL { get; private set; } = "https://official-joke-api.appspot.com/random_joke";

        public JokeService(IBaseRequest service)
        {
            _service = service;
        }

        public BaseDto InitializeAndLoad()
        {
            var result = _service.InitializeAndLoad(URL, new JokeEntity());

            return new BaseDto(result._StatusCode, result._Data == null ? new { Message = result._Message } : result._Data);
        }
    }
}
