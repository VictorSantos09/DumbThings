using Application.Dto;

namespace Dumb.Application.Interfaces
{
    public interface IRequest
    {
        public BaseDto InitializeAndLoad();
    }
}
