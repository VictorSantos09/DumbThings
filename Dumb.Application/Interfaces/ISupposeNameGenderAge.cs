using Application.Dto;

namespace Dumb.Application.Interfaces
{
    public interface ISupposeNameGenderAge
    {
        public BaseDto InitializeAndLoad(string name);
        public string? LoadGender(string name);
        public int? LoadAge(string name);
        public string UrlAge { get; }
        public string UrlGender { get; }
    }
}