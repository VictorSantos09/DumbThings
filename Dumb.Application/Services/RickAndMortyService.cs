using Application.Dto;
using Dumb.Application.Dto;
using Dumb.Application.Interfaces;
using Dumb.Domain.Entities;

namespace Dumb.Application.Services
{
    public class RickAndMortyService : IRequest
    {
        private readonly BaseService<RickAndMortyEntity> _service;
        private readonly List<object> _caracteres;
        private object _wrongCharacter1;
        private object _wrongCharacter2;
        private object _correctCharacter;

        public RickAndMortyService()
        {
            _service = new BaseService<RickAndMortyEntity>();
            _caracteres = new List<object>();
            _wrongCharacter1 = new object();
            _wrongCharacter2 = new object();
            _correctCharacter = new object();
        }

        public BaseDto InitializeAndLoad()
        {
            _caracteres.Clear();

            var caracteres = Get3Caracteres();
            SelectCorrectChoice();

            return new BaseDto(caracteres._StatusCode, new RickAndMortyDto(_wrongCharacter1, _wrongCharacter2, _correctCharacter));
        }
        private BaseDto Get3CaracteresREST(string[] caracteres)
        {
            var index = 0;

            var result1 = _service.InitializeAndLoad($"https://rickandmortyapi.com/api/character/{caracteres[index++]}", new RickAndMortyEntity());
            var result2 = _service.InitializeAndLoad($"https://rickandmortyapi.com/api/character/{caracteres[index++]}", new RickAndMortyEntity());
            var result3 = _service.InitializeAndLoad($"https://rickandmortyapi.com/api/character/{caracteres[index++]}", new RickAndMortyEntity());

            _caracteres.Add(result1._Data);
            _caracteres.Add(result2._Data);
            _caracteres.Add(result3._Data);

            return new BaseDto(result3._StatusCode, _caracteres);
        }
        private string[] Create3RandomsIDs()
        {
            Random rand = new();
            int numberCaracteres = 827;

            var caracter1 = Convert.ToString(rand.Next(0, numberCaracteres));
            var caracter2 = Convert.ToString(rand.Next(0, numberCaracteres));
            var caracter3 = Convert.ToString(rand.Next(0, numberCaracteres));

            return new string[] { caracter1, caracter2, caracter3 };
        }
        public BaseDto Get3Caracteres()
        {
            var result = Get3CaracteresREST(Create3RandomsIDs());

            return new BaseDto(result._StatusCode, result._Data);
        }
        private void SelectCorrectChoice()
        {
            var caracterArray = _caracteres.ToArray();

            _wrongCharacter1 = caracterArray[0];
            _wrongCharacter2 = caracterArray[1];
            _correctCharacter = caracterArray[2];
        }
    }
}