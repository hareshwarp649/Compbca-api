namespace bca.api.DTOs
{
    public class IndianClientLogoUploadDTO
    {
        public IFormFile Logo { get; set; }

        public string ClientName { get; set; }

        public string? WebsiteUrl { get; set; }
    }
}
