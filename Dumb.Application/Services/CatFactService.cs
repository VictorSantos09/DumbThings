using Application.Dto;
using Dumb.Application.Interfaces;
using Dumb.Domain.Entities;

namespace Dumb.Application.Services
{
    public class CatFactService : IServiceRequest
    {
        private readonly IBaseRequest _service;
        public string URL { get; private set; } = "https://catfact.ninja/fact";

        public CatFactService(IBaseRequest service)
        {
            _service = service;
        }

        public BaseDto InitializeAndLoad()
        {
            var result = _service.InitializeAndLoad(URL, new CatFactEntity());

            return new BaseDto(result._StatusCode, result._Data == null ? new { Message = result._Message } : result._Data);
        }
    }
}
