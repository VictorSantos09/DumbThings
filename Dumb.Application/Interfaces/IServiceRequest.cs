using Application.Dto;

namespace Dumb.Application.Interfaces
{
    public interface IServiceRequest
    {
        public BaseDto InitializeAndLoad();
        string URL { get; }
    }
}
