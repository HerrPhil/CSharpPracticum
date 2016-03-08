using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using DealerOrders.Filters;
using DealerOrders.Models;
using DealerOrders.Services;
using DealerOrders.ViewModels;

namespace DealerOrders.Controllers
{
    public class BulkUploadController : AsyncController
    {
        [HeaderFooterFilter]
        [AdminFilter]
        public ActionResult Index()
        {
            return View(new FileUploadViewModel());
        }

        [AdminFilter]
        public async Task<ActionResult> Upload(FileUploadViewModel model)
        {
            int thread1 = Thread.CurrentThread.ManagedThreadId;
            List<Order> orders = await Task.Factory.StartNew<List<Order>> (() => GetOrders(model));
            int thread2 = Thread.CurrentThread.ManagedThreadId;
            OrderService service = new OrderService();
            service.UploadOrders(orders);
            return RedirectToAction("Index", "Order");
        }

        private List<Order> GetOrders(FileUploadViewModel model)
        {
            List<Order> orders = new List<Order>();
            StreamReader csvReader = new StreamReader(model.fileUpload.InputStream);
            csvReader.ReadLine();
            while (!csvReader.EndOfStream)
            {
                var line = csvReader.ReadLine();
                var values = line.Split('|');
                Order order = new Order();
                order.vehicle = values[0];
                order.options = values[1];
                order.customer = values[2];
                order.requested = DateTime.Parse(values[3]);
                order.built = DateTime.Parse(values[4]);
                orders.Add(order);
            }
            return orders;
        }
    }
}