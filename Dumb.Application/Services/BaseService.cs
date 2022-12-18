using Application.Dto;
using Dumb.Application.Interfaces;
using System.Net.Http.Headers;
using static Dumb.Domain.Entities.ApiHelper;

namespace Dumb.Application.Services
{
    public class BaseService<T> : IBaseRequest<T>
    {
        public void InitializeClient()
        {
            ApiClient = new HttpClient();
            ApiClient.DefaultRequestHeaders.Accept.Clear();
            ApiClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }
        public async Task<T> LoadContent<T>(string url, T entity)
        {
            using (HttpResponseMessage response = await ApiClient.GetAsync(url))
            {
                if (response.IsSuccessStatusCode)
                {
                    entity = await response.Content.ReadAsAsync<T>();

                    return entity;

                }

                throw new Exception(response.ReasonPhrase);
            }
        }
        public BaseDto InitializeAndLoad<T>(string url, T entity)
        {
            InitializeClient();
            var result = LoadContent(url, entity);

            return new BaseDto(200, result.GetAwaiter().GetResult());
        }
    }
}
