using Microsoft.EntityFrameworkCore;
namespace CSS233_TripLogApp_JohnMoreau.Models
{
    public class TripContext : DbContext
    {
        public TripContext(DbContextOptions<TripContext> options)
            : base(options)
        { }

        public DbSet<Trip> Trips { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Trip>().HasData(
                new Trip
                {
                    Id = 1,
                    Destination = "Portland",
                    StartDate = DateTime.Parse("03/01/2023"),
                    EndDate = DateTime.Parse("03/07/2023"),
                    Accommodation = "The Benson Hotel",
                    AccommodationPhone = "503-555-1234",
                    AccommodationEmail = "staff@thebenson.com",
                    Activity1 = "Get Voodoo dontus",
                    Activity2 = "Walk in the rain",
                    Activity3 = "Go to Powell's"
                },
                new Trip
                {
                    Id = 2,
                    Destination = "Boise",
                    StartDate = DateTime.Parse("06/06/2023"),
                    EndDate = DateTime.Parse("06/14/2023"),
                    Accommodation = "Holiday Inn Express",
                    AccommodationPhone = "507-555-4321",
                    AccommodationEmail = "staff@HolidayInnBoise.com",
                    Activity1 = "Visit family",
                    Activity2 = "See downtown Boise",
                    Activity3 = "Try Idaho Wine"
                },
                new Trip
                {
                    Id = 3,
                    Destination = "New Zealand",
                    StartDate = DateTime.Parse("02/18/2024"),
                    EndDate = DateTime.Parse("03/01/2024"),
                    Accommodation = "Air BNB Auckland",
                    AccommodationPhone = "+64 9-123-4567",
                    AccommodationEmail = "Carly@nzairbnb.com",
                    Activity1 = "Visit The Shire",
                    Activity2 = "See Mt. Doom",
                    Activity3 = "See Glow Worm Caves"
                }) ;
        }

    }


}
