using Application.Dto;

namespace Dumb.Application.Interfaces
{
    /// <summary>
    /// Assina os contratos de APIs para inicializar e buscar conteúdos, Adicione herança com BaseService para acessar InitializeClient
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IBaseRequest
    {
        public void InitializeClient();
        public Task<T> LoadContent<T>(string url, T _entity);
        public BaseDto InitializeAndLoad<T>(string url, T _entity);
    }
}