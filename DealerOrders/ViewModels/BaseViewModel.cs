using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DealerOrders.ViewModels
{
    public class BaseViewModel
    {
        public string DealerName { get; set; }
        public string UserName { get; set; }
        public FooterViewModel FooterData { get; set; }
    }
}