using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace bca.api.Data.Entities
{
    public class ContactUs
    {
        [Key]
        public int Id { get; set; }

        [Required]        
        public string FirstName { get; set; }

        [Required]        
        public string LastName { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Phone]
        public string PhoneNumber { get; set; }

        [Required]
        [MaxLength(1000)]
        public string Message { get; set; }

        
        [Required]
        public int SelectServiceId { get; set; }

        public SelectService SelectService { get; set; }
    }
}
