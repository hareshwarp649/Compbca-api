using System.ComponentModel.DataAnnotations;

namespace bca.api.DTOs
{
    public class IndianClientCreateDTO
    {
        [Required, MaxLength(100)]
        public string FullName { get; set; }

        [Required]
        public string PhoneNumber { get; set; }

        [Required]
        public string Email { get; set; }

        public string? CompanyName { get; set; }

        [MaxLength(15)]
        public string? GSTNumber { get; set; }

        public string State { get; set; }

        public string City { get; set; }

        [Required, MaxLength(10)]
        public string Pincode { get; set; }

        public string ClientType { get; set; }

        [MaxLength(500)]
        public string? AddressLine { get; set; }
    }
}
