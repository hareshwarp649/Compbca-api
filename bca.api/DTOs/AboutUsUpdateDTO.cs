namespace bca.api.DTOs
{
    public class AboutUsUpdateDTO
    {
        public int Id { get; set; }

        public IFormFile? Image { get; set; } // optional for update

        public string Title { get; set; }

        public string Description { get; set; }
    }
}
