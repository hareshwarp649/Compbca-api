namespace bca.api.DTOs
{
    public class BankInput
    {
        public string Name { get; set; } = string.Empty;
        public string? ODCode { get; set; }
        public string? ShortName { get; set; }
    }
}
