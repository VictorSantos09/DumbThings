using Application.Dto;

namespace Dumb.Application.Interfaces
{
    public interface IRequest<T>
    {
        public BaseDto InitializeAndLoad();
    }
}
