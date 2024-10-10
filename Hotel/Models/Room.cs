using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.Models
{
    public class Room
    {
        public int Id { get; set; }
        public string? RoomType { get; set; }
        public int Capacity { get; set; }
        public decimal PricePerNight { get; set; }
        public int Floor { get; set; }

        public virtual List<Booking>? Bookings { get; set; }
    }
}

