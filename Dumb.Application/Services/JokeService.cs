using Application.Dto;
using Dumb.Application.Interfaces;
using Dumb.Domain.Entities;

namespace Dumb.Application.Services
{
    public class JokeService : IRequest
    {
        private readonly BaseService<JokeEntity> _service;
        public JokeService()
        {
            _service = new BaseService<JokeEntity>();
        }
        public BaseDto InitializeAndLoad()
        {
            var result = _service.InitializeAndLoad("https://official-joke-api.appspot.com/random_joke", new JokeEntity());

            return new BaseDto(result._StatusCode, result._Data == null ? new { Message = result._Message } : result._Data);
        }
    }
}
