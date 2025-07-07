namespace bca.api.DTOs
{
    public class BankDetails
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string? ODCode { get; set; }
        public string? ShortName { get; set; }
    }
}
