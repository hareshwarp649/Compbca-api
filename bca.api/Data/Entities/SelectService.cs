using System.ComponentModel.DataAnnotations;

namespace bca.api.Data.Entities
{
    public class SelectService
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string ServiceName { get; set; }

        public DateTime CreatedDateTime { get; set; } = DateTime.Now;
    }
}
