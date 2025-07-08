using System.ComponentModel.DataAnnotations;

namespace bca.api.Data.Entities
{
    public class ClientTestimonial
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string ClientName { get; set; } 

        [MaxLength(250)]
        public string? ClientImageUrl { get; set; }

        [Required]
        [MaxLength(1000)]
        public string Feedback { get; set; } 

        [Range(1, 5)]
        public int Rating { get; set; } 
     
        public string? ClientLocation { get; set; } 

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow; 

    }
}
