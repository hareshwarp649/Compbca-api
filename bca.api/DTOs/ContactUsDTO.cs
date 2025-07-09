namespace bca.api.DTOs
{
    public class ContactUsDTO
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Message { get; set; }
        public int SelectServiceId { get; set; }
        public string? SelectServiceName { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
