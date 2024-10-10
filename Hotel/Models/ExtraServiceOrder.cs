using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.Models
{
    public class ExtraServiceOrder
    {
        public int Id { get; set; }
        public DateTime OrderDate { get; set; }

        public int BookingId { get; set; }
        public virtual Booking? Booking { get; set; }

        public int ExtraServiceId { get; set; }
        public virtual  ExtraService? ExtraService { get; set; }
    }
}
