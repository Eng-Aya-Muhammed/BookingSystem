using BookingSystem.Core.Models;

namespace BookingSystem.Core.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<User> Users { get; }
        IRepository<Trip> Trips { get; }
        IRepository<Reservation> Reservations { get; }
        Task<int> SaveChangesAsync();
    }
}
