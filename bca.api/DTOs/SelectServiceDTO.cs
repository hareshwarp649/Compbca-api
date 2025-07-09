using System.ComponentModel.DataAnnotations;

namespace bca.api.DTOs
{
    public class SelectServiceDTO
    {
        public int? Id { get; set; } // Nullable for Create, Required for Update

        [Required]
        public string ServiceName { get; set; }
    }
}
