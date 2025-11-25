namespace BookLibraryApi.Models.DTOs
{
    public class UpdateBookDto
    {
        public string? Title {get;set;}
        public string? Author { get; set; }
        public int? Year {get;set;}
    }

}