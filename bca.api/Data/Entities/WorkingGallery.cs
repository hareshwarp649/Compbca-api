using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace bca.api.Data.Entities
{
    public class WorkingGallery
    {

        [Key]
        public int Id { get; set; }

        [Required]
        public int HomeMasterId { get; set; }

        public HomeMaster HomeMaster { get; set; }

        [Required]
        public string MediaUrl { get; set; } // Image or video

        [Required]
        public string? Title { get; set; }

        [MaxLength(300)]
        public string? Description { get; set; }
    }
}
