namespace bca.api.DTOs
{
    public class InternationalClientLogoUploadDTO
    {
        public IFormFile Logo { get; set; }

        public string ClientName { get; set; }

        public string? WebsiteUrl { get; set; }
    }
}
