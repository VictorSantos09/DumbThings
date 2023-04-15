using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dumb.Domain
{
    public interface IEndPoints
    {
        public static string CatFact { get; private set; } = "https://catfact.ninja/fact";
        public static string Joke { get; private set; } = "https://official-joke-api.appspot.com/random_joke";
        public static string Gender { get; private set; } = "https://api.genderize.io?name=";
        public static string Name { get; private set; } = "https://api.agify.io?name=";
        public static string RickAndMorty { get; private set; } = "https://rickandmortyapi.com/api/character/";
        public static string RandomDog { get; private set; } = "https://dog.ceo/api/breeds/image/random";
        public static int RickAndMortyTotalCharacters { get; private set; } = 827;
    }
}
