using System.ComponentModel.DataAnnotations;

namespace bca.api.DTOs
{
    public class ContactUsCreateDTO
    {
        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        public string Email { get; set; }

        public string PhoneNumber { get; set; }

        [Required]
        [MaxLength(1000)]
        public string Message { get; set; }

        [Required]
        public int SelectServiceId { get; set; }
    }
}
