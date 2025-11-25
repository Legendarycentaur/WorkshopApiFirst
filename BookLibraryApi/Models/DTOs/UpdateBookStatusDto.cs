namespace BookLibraryApi.Models.DTOs
{
    public class UpdateBookStatusDTO
    {
        public string? ISBN { get; set; }
        public bool? Status { get; set; }
    }
}
