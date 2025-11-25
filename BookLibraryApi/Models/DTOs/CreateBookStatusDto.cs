using System.ComponentModel.DataAnnotations;
namespace BookLibraryApi.Models.DTOs
{
    public class CreateBookStatusDTO
    {
        [Required(ErrorMessage = "ISBN krävs")]
        [StringLength(200, MinimumLength = 1)]
        public string ISBN { get; set; }

        [Required(ErrorMessage = "Status krävs")]
        public bool Status { get; set; }
    }
}
