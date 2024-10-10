﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.Models
{
    public class ExtraService
    {
        public int Id { get; set; }
        public string? ServiceName { get; set; }
        public string? Description { get; set; }
        public decimal Price { get; set; }

        public virtual List<ExtraServiceOrder>? ExtraServiceOrders { get; set; }
    }
}
