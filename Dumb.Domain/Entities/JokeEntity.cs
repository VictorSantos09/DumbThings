namespace Dumb.Domain.Entities
{
    public class JokeEntity
    {
        public string Setup { get; set; }
        public string Punchline { get; set; }

        public JokeEntity(string setup, string punchline)
        {
            Setup = setup;
            Punchline = punchline;
        }
    }
}
