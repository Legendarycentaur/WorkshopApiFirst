namespace BookLibraryApi.Models.DTOs
{
    public class UpdateBookStatusDTO
    {
        public string? BookstatusId { get; set; }
        public string? ISBN { get; set; }
        public bool? Status { get; set; }
    }
}
