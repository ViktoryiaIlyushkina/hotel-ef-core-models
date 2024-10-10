using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.Models
{
    public class ServiceOrder
    {
        public int Id { get; set; }
        public DateTime OrderDate { get; set; }
        public int Quantity { get; set; }

        public int BookingId { get; set; }
        public virtual Booking? Booking { get; set; }

        public int ServiceId { get; set; }
        public virtual Service? Service { get; set; }
    }
}
