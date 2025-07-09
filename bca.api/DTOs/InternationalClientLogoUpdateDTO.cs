namespace bca.api.DTOs
{
    public class InternationalClientLogoUpdateDTO
    {
        public int Id { get; set; }

        public IFormFile? Logo { get; set; }

        public string ClientName { get; set; }

        public string? WebsiteUrl { get; set; }
    }
}
