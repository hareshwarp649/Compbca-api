using System.ComponentModel.DataAnnotations;

namespace bca.api.DTOs
{
    public class ClientTestimonialUploadDTO
    {
        public IFormFile? ClientImage { get; set; }

        [Required]
        public string ClientName { get; set; }

        [Required]
        [MaxLength(1000)]
        public string Feedback { get; set; }

        [Range(1, 5)]
        public int Rating { get; set; }

        public string? ClientLocation { get; set; }
    }
}
