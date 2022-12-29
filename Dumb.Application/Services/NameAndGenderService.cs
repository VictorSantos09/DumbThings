using Application.Dto;
using Dumb.Application.Interfaces;
using Dumb.Domain.Entities;
using static System.Net.WebRequestMethods;

namespace Dumb.Application.Services
{
    public class NameAndGenderService : ISupposeNameGenderAge
    {
        private readonly IBaseRequest _service;
        public string UrlGender { get; private set; } = "https://api.genderize.io?name=";
        public string UrlAge { get; private set; } = "https://api.agify.io?name=";

        public NameAndGenderService(IBaseRequest baseRequest)
        {
            _service = baseRequest;
        }

        public BaseDto InitializeAndLoad(string name)
        {
            _service.InitializeClient();

            var age = LoadAge(name);
            var gender = LoadGender(name);

            var user = new SupposeUserEntity()
            {
                Name = name,
                Gender = gender,
                Age = age.Value,
            };

            return new BaseDto(200, user);
        }
        public string? LoadGender(string name)
        {
            return _service.LoadContent($"{UrlGender}{name}", new SupposeUserEntity()).GetAwaiter().GetResult().Gender;
        }
        public int? LoadAge(string name)
        {
            return _service.LoadContent($"{UrlAge}{name}", new SupposeUserEntity()).GetAwaiter().GetResult().Age;
        }
    }
}