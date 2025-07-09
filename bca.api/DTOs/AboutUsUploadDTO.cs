using System.ComponentModel.DataAnnotations;

namespace bca.api.DTOs
{
    public class AboutUsUploadDTO
    {
        public IFormFile Image { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }
    }
}
