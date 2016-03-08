using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DealerOrders.ViewModels;

namespace DealerOrders.ViewModels
{
    public class OrderListViewModel:BaseViewModel
    {
        public List<OrderViewModel> Orders { get; set; }
    }
}