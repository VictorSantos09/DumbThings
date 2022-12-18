using Application.Dto;
using Dumb.Application.Interfaces;
using Dumb.Domain.Entities;

namespace Dumb.Application.Services
{
    public class CatFactService : IRequest
    {
        private readonly BaseService<CatFactEntity> _service;

        public CatFactService()
        {
            _service = new BaseService<CatFactEntity>();
        }

        public BaseDto InitializeAndLoad()
        {
            var result = _service.InitializeAndLoad("https://catfact.ninja/fact", new CatFactEntity());

            return new BaseDto(result._StatusCode, result._Data == null ? new { Message = result._Message } : result._Data);
        }
    }
}
