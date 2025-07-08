using System.ComponentModel.DataAnnotations;

namespace bca.api.Data.Entities
{
    public class InternationalClientLogo
    {
        [Key]
        public int Id { get; set; }

       
        public string ClientName { get; set; } 

        [Required]
        public string LogoImageUrl { get; set; } 

        
        public string? WebsiteUrl { get; set; } 

       

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}
