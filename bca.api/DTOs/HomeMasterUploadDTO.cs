namespace bca.api.DTOs
{
    public class HomeMasterUploadDTO
    {
        public IFormFile? BannerImage { get; set; }
        public IFormFile? TeamGroupImage { get; set; }

        public string MainTitle { get; set; }
        public string? SubTitle { get; set; }

        public string AboutCompany { get; set; }
        public string? WhyChooseUs { get; set; }
        public string? YearsOfExperience { get; set; }

        public string? ServiceHighlightOne { get; set; }
        public string? ServiceHighlightTwo { get; set; }
        public string? ServiceHighlightThree { get; set; }

        public string? CustomerReviewSectionTitle { get; set; }
        public string? FeaturedProductSectionTitle { get; set; }

        public string? TeamDescription { get; set; }

        public List<IFormFile> GalleryImages { get; set; }
    }
}
