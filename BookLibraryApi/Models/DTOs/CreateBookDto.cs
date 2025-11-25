using System.ComponentModel.DataAnnotations;

namespace BookLibraryApi.Models.DTOs
{
    public class CreateBookDTO
    {
        [Required(ErrorMessage = "Titel krävs")]
        [StringLength(200, MinimumLength = 1)]
        public string Title {get;set;}

        [Required(ErrorMessage = "Titel krävs")]
        [StringLength(200, MinimumLength = 1)]
        public string Author {get;set;}

        [Required(ErrorMessage = "Titel krävs")]
        [StringLength(200, MinimumLength = 1)]
        public string ISBN {get;set;}

        [Range(1800, 2100, ErrorMessage = "År måste vara mellan 1800 och 2100")]
        public int Year {get;set;}

    }
}
