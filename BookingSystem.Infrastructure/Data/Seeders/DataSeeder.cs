namespace BookingSystem.Infrastructure.Data.Seeders
{
    using global::BookingSystem.Core.Models;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.EntityFrameworkCore;

    namespace BookingSystem.Infrastructure.Data.Seeders
    {
        public class DataSeeder
        {
            public static async Task SeedAsync(AppDbContext context,
                                             UserManager<User> userManager,
                                             RoleManager<IdentityRole<int>> roleManager)
            {
                await context.Database.MigrateAsync();

                await SeedRolesAsync(roleManager);
                await SeedUsersAsync(userManager);
                await SeedTripsAsync(context);
            }

            private static async Task SeedRolesAsync(RoleManager<IdentityRole<int>> roleManager)
            {
                if (!await roleManager.Roles.AnyAsync())
                {
                    await roleManager.CreateAsync(new IdentityRole<int> { Name = "Admin" });
                    await roleManager.CreateAsync(new IdentityRole<int> { Name = "User" });
                }
            }

            private static async Task SeedUsersAsync(UserManager<User> userManager)
            {
                if (!await userManager.Users.AnyAsync())
                {
                    var adminUser = new User
                    {
                        UserName = "admin",
                        Email = "admin@example.com",
                        EmailConfirmed = true
                    };

                    await userManager.CreateAsync(adminUser, "Admin123!");
                    await userManager.AddToRoleAsync(adminUser, "Admin");

                    var normalUser = new User
                    {
                        UserName = "user1",
                        Email = "user1@example.com",
                        EmailConfirmed = true
                    };

                    await userManager.CreateAsync(normalUser, "User123!");
                    await userManager.AddToRoleAsync(normalUser, "User");
                }
            }

            private static async Task SeedTripsAsync(AppDbContext context)
            {
                if (!context.Trips.Any())
                {
                    var trips = new[]
                    {
                    new Trip
                    {
                        Name = "Luxor Adventure",
                        CityName = "Luxor",
                        Price = 500m,
                        ImageUrl = "https://images.unsplash.com/photo-1580502304784-8985b7eb7260?w=800",
                        Content = "Explore the temples and history of Luxor!",
                        CreationDate = DateTime.UtcNow
                    },
                    new Trip
                    {
                        Name = "Sharm El-Sheikh Tour",
                        CityName = "Sharm El-Sheikh",
                        Price = 800m,
                        ImageUrl = "https://images.unsplash.com/photo-1571896349842-33c89424de2d?w=800",
                        Content = "Discover the beaches and diving spots of Sharm El-Sheikh!",
                        CreationDate = DateTime.UtcNow
                    }
                };

                    context.Trips.AddRange(trips);
                    await context.SaveChangesAsync();
                }
            }
        }
    }
}
