using Hotel.Contexts;
using Hotel.Models;
using Microsoft.EntityFrameworkCore;


namespace Hotel
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //// lazy loading
            //using (ApplicationContext db = new ApplicationContext())
            //{
            //    var bookings = db.Bookings.ToList();
            //    foreach (var booking in bookings)
            //    {
            //        Console.WriteLine($"Guest:{booking.Guest!.FirstName} {booking.Guest.FirstName}\n" +
            //                          $"ArrivalDate:{booking.ArrivalDate}\n" +
            //                          $"Room: {booking.Room!.RoomType}\n\n");
            //    }
            //}

            // eager loading
            using (ApplicationContext db = new ApplicationContext())
            {
                var bookings = db.Bookings
                    .Include(b => b.Guest)
                    .Include(b => b.Room)
                    .ToList();

                foreach (var booking in bookings)
                {
                    Console.WriteLine($"Guest:{booking.Guest!.FirstName} {booking.Guest.FirstName} - " +
                                      $"Floor:{booking.Room!.Floor}\n");
                }
            }

            Console.WriteLine("-----------------");

            // eager loading
            using (ApplicationContext db = new ApplicationContext())
            {
                var serviceOrders = db.ServiceOrders
                    .Include(o => o.Service)
                    .Include(o => o.Booking)
                        .ThenInclude(b => b!.Guest)
                    .ToList();

                foreach (var order in serviceOrders)
                {
                    Console.WriteLine($"Guest:{order.Booking.Guest.FirstName} {order.Booking.Guest.LastName} - " +
                                      $"Service:{order.Service.ServiceName}\n");
                }
            }

            Console.WriteLine("-----------------");

            //Explicit loading
            using (ApplicationContext db = new ApplicationContext())
            {
                var booking = db.Bookings.Find(1);
                if(booking != null)
                {
                    db.Entry(booking).Collection(b => b.Reviews).Load();

                    Console.WriteLine($"Departure date:{booking.DepartureDate}\nReviews: " );

                    foreach(var r in booking.Reviews)
                    {
                        Console.WriteLine($"- {r.Comment}");
                    }
                }
            }
        }
    }
}
