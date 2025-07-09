namespace bca.api.DTOs
{
    public class ClientTestimonialDTO
    {
        public int Id { get; set; }
        public string ClientName { get; set; }
        public string? ClientImageUrl { get; set; }
        public string Feedback { get; set; }
        public int Rating { get; set; }
        public string? ClientLocation { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
