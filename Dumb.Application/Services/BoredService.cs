using Application.Dto;
using Dumb.Application.Interfaces;
using Dumb.Domain.Entities;

namespace Dumb.Application.Services
{
    public class BoredService : IServiceRequest
    {
        private readonly IBaseRequest _service;
        public string URL { get; private set; } = "https://www.boredapi.com/api/activity";

        public BoredService(IBaseRequest baseRequest)
        {
            _service = baseRequest;
        }

        public BaseDto InitializeAndLoad()
        {
            var result = _service.InitializeAndLoad(URL, new BoredEntity());

            return new BaseDto(result._StatusCode, result._Data == null ? new { Message = result._Message } : result._Data);
        }
    }
}
