﻿using System.ComponentModel.DataAnnotations;

namespace bca.api.Data.Entities
{
    public class AboutUs
    {
        [Key]
        public int Id { get; set; }

       
       
        public string Title { get; set; }

        
        public string Description { get; set; }

        public string? FilePath { get; set; }
        public string? ImageUrl { get; set; } // Optional: for an image on the About Us page

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}
