using BookingSystem.Core.Interfaces;
using BookingSystem.Core.Models;
using BookingSystem.Infrastructure.Data;

namespace BookingSystem.Infrastructure.Repositories
{
    public class UnitOfWork(AppDbContext context) : IUnitOfWork
    {
        public IRepository<User> Users { get; } = new Repository<User>(context);
        public IRepository<Trip> Trips { get; } = new Repository<Trip>(context);
        public IRepository<Reservation> Reservations { get; } = new Repository<Reservation>(context);

        public async Task<int> SaveChangesAsync() => await context.SaveChangesAsync();

        public void Dispose() => context.Dispose();
    }

}
