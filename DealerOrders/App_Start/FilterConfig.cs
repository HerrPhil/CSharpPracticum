using DealerOrders.Filters;
using System.Web;
using System.Web.Mvc;

namespace DealerOrders
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            //filters.Add(new HandleErrorAttribute()); // Exception Filter
            filters.Add(new OrderExceptionFilter()); // Exception Filter
            filters.Add(new AuthorizeAttribute());
        }
    }
}
