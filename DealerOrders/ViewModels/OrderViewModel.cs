using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DealerOrders.ViewModels
{
    public class OrderViewModel
    {
        public string Vehicle { get; set; }
        public string VehicleColor { get; set; }
        public string VehicleOptions { get; set; }
        public string Customer { get; set; }
        public string ImportantDates { get; set; } // requested + built
    }
}