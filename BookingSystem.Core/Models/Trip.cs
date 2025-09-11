namespace BookingSystem.Core.Models
{
    public class Trip
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string CityName { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public string? ImageUrl { get; set; }
        public string? Content { get; set; }
        public DateTime CreationDate { get; set; } = DateTime.UtcNow;
    }
}
