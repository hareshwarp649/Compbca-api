namespace bca.api.Data.Entities
{
    public class Bank
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string? ODCode { get; set; }
        public string? ShortName { get; set; }

        // One Bank has many Locations
        //public ICollection<Location> Locations { get; set; } = new List<Location>();
    }
}
