namespace Dumb.Application.Dto
{
    public class RickAndMortyDto
    {
        public object WrongChoice1 { get; set; }
        public object WrongChoice2 { get; set; }
        public object CorrectChoice { get; set; }

        public RickAndMortyDto(object wrongChoice1, object wrongChoice2, object correctChoice)
        {
            WrongChoice1 = wrongChoice1;
            WrongChoice2 = wrongChoice2;
            CorrectChoice = correctChoice;
        }
    }
}
