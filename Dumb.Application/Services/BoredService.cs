using Application.Dto;
using Dumb.Application.Interfaces;
using Dumb.Domain.Entities;

namespace Dumb.Application.Services
{
    public class BoredService : IRequest
    {
        private readonly BaseService<BoredEntity> _service;

        public BoredService()
        {
            _service = new BaseService<BoredEntity>();
        }

        public BaseDto InitializeAndLoad()
        {
            var result = _service.InitializeAndLoad("https://www.boredapi.com/api/activity", new BoredEntity());

            return new BaseDto(result._StatusCode, result._Data == null ? new { Message = result._Message } : result._Data);
        }
    }
}
