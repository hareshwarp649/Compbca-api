using System.ComponentModel.DataAnnotations;

namespace bca.api.Data.Entities
{
    public class AboutUs
    {
        [Key]
        public int Id { get; set; }

        [Required]
       
        public string Title { get; set; }

        [Required]
        public string Description { get; set; }

      
        public string? ImageUrl { get; set; } // Optional: for an image on the About Us page

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}
