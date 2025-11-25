namespace BookLibraryApi.Models.DTOs
{
    public class UpdateBookDto
    {
        public string? Title {get;set;}
        public string? Author {get;set;}
        public string? ISBN {get;set;}
        public int? Year {get;set;}
        public bool? IsAvailable {get;set;}
    }

}