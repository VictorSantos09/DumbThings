using Application.Dto;
using Dumb.Application.Interfaces;
using Dumb.Domain.Entities;

namespace Dumb.Application.Services
{
    public class NameAndGenderService : ISupposeNameGenderAge
    {
        private readonly BaseService<SupposeUserEntity> _service;

        public NameAndGenderService()
        {
            _service = new BaseService<SupposeUserEntity>();
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
            return _service.LoadContent($"https://api.genderize.io?name={name}", new SupposeUserEntity()).GetAwaiter().GetResult().Gender;
        }
        public int? LoadAge(string name)
        {
            return _service.LoadContent($"https://api.agify.io?name={name}", new SupposeUserEntity()).GetAwaiter().GetResult().Age;
        }
    }
}