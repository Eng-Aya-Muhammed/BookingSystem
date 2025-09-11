namespace BookingSystem.Core.Models
{
    public class Reservation
    {
        public int Id { get; set; }
        public int ReservedById { get; set; }
        public User ReservedBy { get; set; } = null!;
        public string CustomerName { get; set; } = string.Empty;
        public int TripId { get; set; }
        public Trip Trip { get; set; } = null!;
        public DateTime ReservationDate { get; set; }
        public DateTime CreationDate { get; set; } = DateTime.UtcNow;
        public string? Notes { get; set; }
    }
}
