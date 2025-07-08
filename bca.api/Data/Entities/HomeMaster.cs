using System.ComponentModel.DataAnnotations;

namespace bca.api.Data.Entities
{
    public class HomeMaster
    {

        [Key]
        public int Id { get; set; }

        [Required]
        public string MainTitle { get; set; }

        public string? SubTitle { get; set; }

        public string? BannerImageUrl { get; set; }

        [Required]
        public string AboutCompany { get; set; }

        [MaxLength(300)]
        public string? WhyChooseUs { get; set; }

        public string? YearsOfExperience { get; set; }

        [MaxLength(300)]
        public string? ServiceHighlightOne { get; set; }

        [MaxLength(300)]
        public string? ServiceHighlightTwo { get; set; }

        [MaxLength(300)]
        public string? ServiceHighlightThree { get; set; }
      
        public string? CustomerReviewSectionTitle { get; set; }

        public string? FeaturedProductSectionTitle { get; set; }

        // ✅ Our Team Section (Group Info)
        public string? TeamGroupImageUrl { get; set; }

        public string? TeamDescription { get; set; }

        // ✅ Working Gallery Section
        public ICollection<WorkingGallery> WorkingGalleries { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;


    }
}
