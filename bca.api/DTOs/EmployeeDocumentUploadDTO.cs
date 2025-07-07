using bca.api.Enums;

namespace bca.api.DTOs
{
    public class EmployeeDocumentUploadDTO
    {
        public int EmployeeId { get; set; }
        public DocumentType DocumentType { get; set; }
        public IFormFile File { get; set; } = default!;
    }
}
