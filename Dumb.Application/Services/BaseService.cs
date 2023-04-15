using Application.Dto;
using Dumb.Application.Interfaces;
using System.Net;
using System.Net.Http.Headers;
using Dumb.Domain;
using Dumb.Domain.Entities;

namespace Dumb.Application.Services
{
    public class BaseService : IBaseRequest
    {
        private ApiHelper _apiHelper;
        public void InitializeClient()
        {
            _apiHelper = new ApiHelper(new HttpClient());
            _apiHelper.ApiClient.DefaultRequestHeaders.Accept.Clear();
            _apiHelper.ApiClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }
        public async Task<T> LoadContent<T>(string url, T entity)
        {
            System.Net.ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;

            using (HttpResponseMessage response = await _apiHelper.ApiClient.GetAsync(url))
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
