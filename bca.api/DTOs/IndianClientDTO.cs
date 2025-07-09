namespace bca.api.DTOs
{
    public class IndianClientDTO
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string? CompanyName { get; set; }
        public string? GSTNumber { get; set; }
        public string State { get; set; }
        public string City { get; set; }
        public string Pincode { get; set; }
        public string ClientType { get; set; }
        public string? AddressLine { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
