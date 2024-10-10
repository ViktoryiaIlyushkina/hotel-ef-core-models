using Hotel.Contexts;
using Hotel.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace Hotel.Contexts
{
    internal class ApplicationContext : DbContext
    {
        public DbSet<Booking> Bookings { get; set; }
        public DbSet<Guest> Guests { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<Service> Services { get; set; }
        public DbSet<ServiceOrder> ServiceOrders { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<ExtraServiceOrder> ExtraServiceOrders { get; set; }
        public DbSet<ExtraService> ExtraServices { get; set; }
        public DbSet<Staff> Staffs { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var connectionString = @"Server=(localdb)\mssqllocaldb; Database=HotelDb; Trusted_Connection=True;";
            //// lazy loading
            //optionsBuilder.UseLazyLoadingProxies().UseSqlServer(connectionString);

            //Eager loaging and explicit loading
            optionsBuilder.UseSqlServer(connectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Guest>().HasData(
                 new Guest { Id = 1, FirstName = "John", LastName = "Doe", Email = "john.doe@example.com", PhoneNumber = "123-456-7890" },
                 new Guest { Id = 2, FirstName = "Jane", LastName = "Smith", Email = "jane.smith@example.com", PhoneNumber = "987-654-3210" },
                 new Guest { Id = 3, FirstName = "Alice", LastName = "Johnson", Email = "alice.johnson@example.com", PhoneNumber = "555-123-4567" },
                 new Guest { Id = 4, FirstName = "Bob", LastName = "Williams", Email = "bob.williams@example.com", PhoneNumber = "555-456-7890" },
                 new Guest { Id = 5, FirstName = "Charlie", LastName = "Brown", Email = "charlie.brown@example.com", PhoneNumber = "555-789-0123" },
                 new Guest { Id = 6, FirstName = "David", LastName = "Davis", Email = "david.davis@example.com", PhoneNumber = "555-012-3456" },
                 new Guest { Id = 7, FirstName = "Emily", LastName = "Wilson", Email = "emily.wilson@example.com", PhoneNumber = "555-345-6789" },
                 new Guest { Id = 8, FirstName = "Frank", LastName = "Moore", Email = "frank.moore@example.com", PhoneNumber = "555-678-9012" },
                 new Guest { Id = 9, FirstName = "Grace", LastName = "Taylor", Email = "grace.taylor@example.com", PhoneNumber = "555-901-2345" },
                 new Guest { Id = 10, FirstName = "Henry", LastName = "Anderson", Email = "henry.anderson@example.com", PhoneNumber = "555-234-5678" }
             );

            modelBuilder.Entity<Room>().HasData(
                new Room { Id = 1, RoomType = "Standard", Capacity = 2, PricePerNight = 100.00m, Floor = 1 },
                new Room { Id = 2, RoomType = "Suite", Capacity = 4, PricePerNight = 200.00m, Floor = 2 },
                new Room { Id = 3, RoomType = "Standard", Capacity = 2, PricePerNight = 100.00m, Floor = 1 },
                new Room { Id = 4, RoomType = "Suite", Capacity = 4, PricePerNight = 200.00m, Floor = 2 },
                new Room { Id = 5, RoomType = "Standard", Capacity = 2, PricePerNight = 100.00m, Floor = 1 },
                new Room { Id = 6, RoomType = "Suite", Capacity = 4, PricePerNight = 200.00m, Floor = 2 },
                new Room { Id = 7, RoomType = "Standard", Capacity = 2, PricePerNight = 100.00m, Floor = 1 },
                new Room { Id = 8, RoomType = "Suite", Capacity = 4, PricePerNight = 200.00m, Floor = 2 },
                new Room { Id = 9, RoomType = "Standard", Capacity = 2, PricePerNight = 100.00m, Floor = 1 },
                new Room { Id = 10, RoomType = "Suite", Capacity = 4, PricePerNight = 200.00m, Floor = 2 }
            );

            modelBuilder.Entity<Booking>().HasData(
                new Booking { Id = 1, GuestId = 1, RoomId = 1, ArrivalDate = new DateTime(2023, 10, 26), DepartureDate = new DateTime(2023, 10, 29) },
                new Booking { Id = 2, GuestId = 2, RoomId = 2, ArrivalDate = new DateTime(2023, 11, 15), DepartureDate = new DateTime(2023, 11, 18) },
                new Booking { Id = 3, GuestId = 3, RoomId = 3, ArrivalDate = new DateTime(2023, 12, 01), DepartureDate = new DateTime(2023, 12, 04) },
                new Booking { Id = 4, GuestId = 4, RoomId = 4, ArrivalDate = new DateTime(2024, 01, 05), DepartureDate = new DateTime(2024, 01, 08) },
                new Booking { Id = 5, GuestId = 5, RoomId = 5, ArrivalDate = new DateTime(2024, 02, 10), DepartureDate = new DateTime(2024, 02, 13) },
                new Booking { Id = 6, GuestId = 6, RoomId = 6, ArrivalDate = new DateTime(2024, 03, 15), DepartureDate = new DateTime(2024, 03, 18) },
                new Booking { Id = 7, GuestId = 7, RoomId = 7, ArrivalDate = new DateTime(2024, 04, 20), DepartureDate = new DateTime(2024, 04, 23) },
                new Booking { Id = 8, GuestId = 8, RoomId = 8, ArrivalDate = new DateTime(2024, 05, 25), DepartureDate = new DateTime(2024, 05, 28) },
                new Booking { Id = 9, GuestId = 9, RoomId = 9, ArrivalDate = new DateTime(2024, 06, 30), DepartureDate = new DateTime(2024, 07, 03) },
                new Booking { Id = 10, GuestId = 10, RoomId = 10, ArrivalDate = new DateTime(2024, 08, 05), DepartureDate = new DateTime(2024, 08, 08) }
            );

            modelBuilder.Entity<Service>().HasData(
                new Service { Id = 1, ServiceName = "Cleaning", Description = "Daily room cleaning", Price = 10.00m, ServiceType = "Cleaning" },
                new Service { Id = 2, ServiceName = "Breakfast", Description = "Continental breakfast", Price = 15.00m, ServiceType = "Breakfast" },
                new Service { Id = 3, ServiceName = "Laundry", Description = "Laundry service", Price = 20.00m, ServiceType = "Services" },
                new Service { Id = 4, ServiceName = "Room service", Description = "In-room dining", Price = 25.00m, ServiceType = "Services" },
                new Service { Id = 5, ServiceName = "Transfer", Description = "Airport transfer", Price = 30.00m, ServiceType = "Services" },
                new Service { Id = 6, ServiceName = "Lunch", Description = "Lunch at the restaurant", Price = 15.00m, ServiceType = "Dining" },
                new Service { Id = 7, ServiceName = "Dinner", Description = "Dinner at the restaurant", Price = 20.00m, ServiceType = "Dining" },
                new Service { Id = 8, ServiceName = "Bar", Description = "Drinks and snacks", Price = 10.00m, ServiceType = "Services" },
                new Service { Id = 9, ServiceName = "Wi-Fi", Description = "Wi-Fi access", Price = 5.00m, ServiceType = "Services" },
                new Service { Id = 10, ServiceName = "Home theater", Description = "Movie watching", Price = 15.00m, ServiceType = "Services" } 
            );

            modelBuilder.Entity<Staff>().HasData(
                new Staff { Id = 1, FirstName = "Peter", LastName = "Smith", Position = "Manager", Department = "Administration" },
                new Staff { Id = 2, FirstName = "Mary", LastName = "Jones", Position = "Receptionist", Department = "Administration" },
                new Staff { Id = 3, FirstName = "David", LastName = "Brown", Position = "Chef", Department = "Kitchen" },
                new Staff { Id = 4, FirstName = "Lisa", LastName = "Wilson", Position = "Waiter", Department = "Restaurant" },
                new Staff { Id = 5, FirstName = "Michael", LastName = "Davis", Position = "Maid", Department = "Cleaning" },
                new Staff { Id = 6, FirstName = "Susan", LastName = "Garcia", Position = "Bartender", Department = "Bar" },
                new Staff { Id = 7, FirstName = "John", LastName = "Rodriguez", Position = "Driver", Department = "Transfer" },
                new Staff { Id = 8, FirstName = "Jennifer", LastName = "Martinez", Position = "Technician", Department = "Technical Department" },
                new Staff { Id = 9, FirstName = "Thomas", LastName = "Robinson", Position = "Housekeeper", Department = "Cleaning" },
                new Staff { Id = 10, FirstName = "Patricia", LastName = "Lee", Position = "Accountant", Department = "Finance Department" }
            );

            modelBuilder.Entity <ServiceOrder>().HasData(
                new ServiceOrder { Id = 1, BookingId = 1, ServiceId = 1, OrderDate = new DateTime(2023, 10, 27), Quantity = 1 },
                new ServiceOrder { Id = 2, BookingId = 2, ServiceId = 2, OrderDate = new DateTime(2023, 11, 16), Quantity = 2 },
                new ServiceOrder { Id = 3, BookingId = 3, ServiceId = 3, OrderDate = new DateTime(2023, 12, 02), Quantity = 1 },
                new ServiceOrder { Id = 4, BookingId = 4, ServiceId = 4, OrderDate = new DateTime(2024, 01, 06), Quantity = 1 },
                new ServiceOrder { Id = 5, BookingId = 5, ServiceId = 5, OrderDate = new DateTime(2024, 02, 11), Quantity = 1 },
                new ServiceOrder { Id = 6, BookingId = 6, ServiceId = 6, OrderDate = new DateTime(2024, 03, 16), Quantity = 1 },
                new ServiceOrder { Id = 7, BookingId = 7, ServiceId = 7, OrderDate = new DateTime(2024, 04, 21), Quantity = 1 },
                new ServiceOrder { Id = 8, BookingId = 8, ServiceId = 8, OrderDate = new DateTime(2024, 05, 26), Quantity = 1 },
                new ServiceOrder { Id = 9, BookingId = 9, ServiceId = 9, OrderDate = new DateTime(2024, 06, 30), Quantity = 1 },
                new ServiceOrder { Id = 10, BookingId = 10, ServiceId = 10, OrderDate = new DateTime(2024, 08, 06), Quantity = 1 }
            );

            modelBuilder.Entity<Payment>().HasData(
                new Payment { Id = 1, BookingId = 1, PaymentDate = new DateTime(2023, 10, 25), Amount = 300.00m, PaymentMethod = "Card" },
                new Payment { Id = 2, BookingId = 2, PaymentDate = new DateTime(2023, 11, 14), Amount = 600.00m, PaymentMethod = "Cash" },
                new Payment { Id = 3, BookingId = 3, PaymentDate = new DateTime(2023, 11, 30), Amount = 400.00m, PaymentMethod = "Card" },
                new Payment { Id = 4, BookingId = 4, PaymentDate = new DateTime(2024, 01, 04), Amount = 800.00m, PaymentMethod = "Cash" },
                new Payment { Id = 5, BookingId = 5, PaymentDate = new DateTime(2024, 02, 09), Amount = 500.00m, PaymentMethod = "Card" },
                new Payment { Id = 6, BookingId = 6, PaymentDate = new DateTime(2024, 03, 14), Amount = 700.00m, PaymentMethod = "Cash" },
                new Payment { Id = 7, BookingId = 7, PaymentDate = new DateTime(2024, 04, 19), Amount = 300.00m, PaymentMethod = "Card" },
                new Payment { Id = 8, BookingId = 8, PaymentDate = new DateTime(2024, 05, 24), Amount = 600.00m, PaymentMethod = "Cash" },
                new Payment { Id = 9, BookingId = 9, PaymentDate = new DateTime(2024, 06, 29), Amount = 400.00m, PaymentMethod = "Card" },
                new Payment { Id = 10, BookingId = 10, PaymentDate = new DateTime(2024, 08, 04), Amount = 800.00m, PaymentMethod = "Cash" }
            );

            modelBuilder.Entity<ExtraService>().HasData(
                new ExtraService { Id = 1, ServiceName = "Wi-Fi", Description = "Wi-Fi access", Price = 5.00m },
                new ExtraService { Id = 2, ServiceName = "Mini-bar", Description = "Drinks and snacks in the mini-bar", Price = 10.00m },
                new ExtraService { Id = 3, ServiceName = "Early check-in", Description = "Check-in before standard time", Price = 20.00m },
                new ExtraService { Id = 4, ServiceName = "Late check-out", Description = "Check-out after standard time", Price = 25.00m },
                new ExtraService { Id = 5, ServiceName = "Extra bed", Description = "Extra bed in the room", Price = 15.00m },
                new ExtraService { Id = 6, ServiceName = "Baby cot", Description = "Baby cot in the room", Price = 10.00m },
                new ExtraService { Id = 7, ServiceName = "Iron and ironing board", Description = "Ironing services", Price = 5.00m },
                new ExtraService { Id = 8, ServiceName = "Hairdryer", Description = "Hairdryer", Price = 5.00m },
                new ExtraService { Id = 9, ServiceName = "Bathrobe and slippers", Description = "Bathrobe and slippers", Price = 10.00m },
                new ExtraService { Id = 10, ServiceName = "Parking", Description = "Parking space", Price = 15.00m }
            );

            modelBuilder.Entity<ExtraServiceOrder>().HasData(
                new ExtraServiceOrder { Id = 1, BookingId = 1, ExtraServiceId = 1, OrderDate = new DateTime(2023, 10, 26) },
                new ExtraServiceOrder { Id = 2, BookingId = 2, ExtraServiceId = 2, OrderDate = new DateTime(2023, 11, 15) },
                new ExtraServiceOrder { Id = 3, BookingId = 3, ExtraServiceId = 3, OrderDate = new DateTime(2023, 12, 01) },
                new ExtraServiceOrder { Id = 4, BookingId = 4, ExtraServiceId = 4, OrderDate = new DateTime(2024, 01, 05) },
                new ExtraServiceOrder { Id = 5, BookingId = 5, ExtraServiceId = 5, OrderDate = new DateTime(2024, 02, 10) },
                new ExtraServiceOrder { Id = 6, BookingId = 6, ExtraServiceId = 6, OrderDate = new DateTime(2024, 03, 15) },
                new ExtraServiceOrder { Id = 7, BookingId = 7, ExtraServiceId = 7, OrderDate = new DateTime(2024, 04, 20) },
                new ExtraServiceOrder { Id = 8, BookingId = 8, ExtraServiceId = 8, OrderDate = new DateTime(2024, 05, 25) },
                new ExtraServiceOrder { Id = 9, BookingId = 9, ExtraServiceId = 9, OrderDate = new DateTime(2024, 06, 30) },
                new ExtraServiceOrder { Id = 10, BookingId = 10, ExtraServiceId = 10, OrderDate = new DateTime(2024, 08, 05) }
            );

            modelBuilder.Entity<Review>().HasData(
                new Review { Id = 1, FirstName = "John", LastName = "Doe", BookingId = 1, Rating = 4, Comment = "Great hotel! Clean, cozy, friendly staff." },
                new Review { Id = 2, FirstName = "Jane", LastName = "Smith", BookingId = 2, Rating = 5, Comment = "Excellent room with a beautiful view. Highly recommend!" },
                new Review { Id = 3, FirstName = "Alice", LastName = "Johnson", BookingId = 3, Rating = 3, Comment = "Overall not bad, but breakfast could be better." },
                new Review { Id = 4, FirstName = "Bob", LastName = "Williams", BookingId = 4, Rating = 4, Comment = "Good location, easy access to transportation." },
                new Review { Id = 5, FirstName = "Charlie", LastName = "Brown", BookingId = 5, Rating = 5, Comment = "Superb service, staff very attentive." },
                new Review { Id = 6, FirstName = "David", LastName = "Davis", BookingId = 6, Rating = 4, Comment = "Clean and comfortable room, great internet." },
                new Review { Id = 7, FirstName = "Emily", LastName = "Wilson", BookingId = 7, Rating = 3, Comment = "The price is a bit overpriced for such a room." },
                new Review { Id = 8, FirstName = "Frank", LastName = "Moore", BookingId = 8, Rating = 5, Comment = "Unforgettable vacation! Everything was just great!" },
                new Review { Id = 9, FirstName = "Grace", LastName = "Taylor", BookingId = 9, Rating = 4, Comment = "Good hotel for business trips." },
                new Review { Id = 10, FirstName = "Henry", LastName = "Anderson", BookingId = 10, Rating = 5, Comment = "Excellent choice for family vacation." }
            );

            modelBuilder.Entity<Guest>().HasKey(guest => guest.Id);
            modelBuilder.Entity<Room>().HasKey(room => room.Id);
            modelBuilder.Entity<Booking>().HasKey(booking => booking.Id);
            modelBuilder.Entity<Service>().HasKey(service => service.Id);
            modelBuilder.Entity<Staff>().HasKey(staff => staff.Id);
            modelBuilder.Entity<ServiceOrder>().HasKey(serviceOrder => serviceOrder.Id);
            modelBuilder.Entity<Payment>().HasKey(payment => payment.Id);
            modelBuilder.Entity<ExtraService>().HasKey(extraService => extraService.Id);
            modelBuilder.Entity<ExtraServiceOrder>().HasKey(extraServiceOrder => extraServiceOrder.Id);
            modelBuilder.Entity<Review>().HasKey(review => review.Id);
        }
    }
}

