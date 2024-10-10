using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.Models
{
    public class Booking
    {
        public int Id { get; set; }
        public DateTime ArrivalDate { get; set; }
        public DateTime DepartureDate { get; set; }

        public int GuestId { get; set; }
        public virtual Guest? Guest { get; set; }

        public int RoomId { get; set; }
        public virtual Room? Room { get; set; }

        public virtual List<Review>? Reviews { get; set; }
        public virtual List<Payment>? Payments { get; set; }
        public virtual List<ServiceOrder>? ServiceOrders { get; set; }
        public virtual List<ExtraServiceOrder>? ExtraServiceOrders { get; set; }
    }
}
