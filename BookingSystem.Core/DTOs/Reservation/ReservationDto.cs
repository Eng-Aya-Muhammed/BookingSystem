namespace BookingSystem.Core.DTOs.Reservation
{
    public record ReservationDto
    {
        public int Id { get; init; }
        public int ReservedById { get; init; }
        public string CustomerName { get; init; } = string.Empty;
        public int TripId { get; init; }
        public string TripName { get; init; } = string.Empty;
        public DateTime ReservationDate { get; init; }
        public DateTime CreationDate { get; init; }
        public string? Notes { get; init; }
    }
}
