using System.Collections.Generic;
using System.Web.Mvc;

namespace DealerOrders.ViewModels
{
    public class CreateOrderViewModel:BaseViewModel
    {
        public string ModelId { get; set; }
        public IEnumerable<SelectListItem> ModelList { get; set; }

        public string Options { get; set; }
        public string Vehicle { get; set; }
        public string Customer { get; set; }
        public string Requested { get; set; }
        public string Built { get; set; }
    }
}