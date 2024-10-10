using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.Models
{
    public class Review
    {
        public int Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public int Rating { get; set; } 
        public string? Comment { get; set; }

        public int BookingId { get; set; }
        public virtual Booking? Booking { get; set; }
    }
}
