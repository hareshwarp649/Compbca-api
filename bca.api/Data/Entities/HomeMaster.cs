using System.ComponentModel.DataAnnotations;

namespace bca.api.Data.Entities
{
    public class HomeMaster
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string Section { get; set; }  // e.g., "hero", "team", "gallery"

        [MaxLength(100)]
        public string Title { get; set; }

        [Required]
        [MaxLength(200)]
        public string ImageUrl { get; set; }  // e.g., "api/images/hero/hero1.jpg"

        [MaxLength(500)]
        public string Description { get; set; }

        
    }
}
