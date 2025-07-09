namespace bca.api.DTOs
{
    public class WorkingGalleryUploadDTO
    {
        public int HomeMasterId { get; set; }

        public IFormFile MediaFile { get; set; }

        public string Title { get; set; }

        //public string? Description { get; set; }
    }
}
