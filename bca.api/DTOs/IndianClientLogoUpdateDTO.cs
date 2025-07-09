namespace bca.api.DTOs
{
    public class IndianClientLogoUpdateDTO
    {
        public int Id { get; set; }

        public IFormFile? Logo { get; set; } // Optional during update

        public string ClientName { get; set; }

        public string? WebsiteUrl { get; set; }
    }
}
