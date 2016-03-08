using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DealerOrders.Filters;
using DealerOrders.Models;
using DealerOrders.Services;
using DealerOrders.ViewModels;

namespace DealerOrders.Controllers
{

    //[Authorize] // controller level authorization is ok too
    public class OrderController : Controller
    {

        // GET: Order
        //[Authorize]
        [HeaderFooterFilter]
        [Route("Order/List")]
        public ActionResult Index()
        {
            OrderListViewModel orderListViewModel = new OrderListViewModel();

            OrderService orderService = new OrderService();

            List<Order> orders = orderService.GetOrders();

            List<OrderViewModel> orderViewModels = new List<OrderViewModel>();

            foreach (Order order in orders)
            {
                OrderViewModel orderViewModel = new OrderViewModel();
                orderViewModel.Vehicle = order.vehicle;
                if (order.vehicle.Contains("Ford"))
                {
                    orderViewModel.VehicleColor = "green";
                }
                else
                {
                    orderViewModel.VehicleColor = "yellow";
                }
                orderViewModel.VehicleOptions = order.options;
                orderViewModel.Customer = order.customer;
                orderViewModel.ImportantDates = "Requested: " + order.requested.ToString("dd MMM yyyy") + " Built: " + order.built.ToString("dd MMM yyyy");
                orderViewModels.Add(orderViewModel);
            }
            orderListViewModel.Orders = orderViewModels;
            orderListViewModel.DealerName = "Local Dealership";

            return View("Index", orderListViewModel);
        }

        [AdminFilter]
        [HeaderFooterFilter]
        public ActionResult AddNew()
        {
            CreateOrderViewModel orderListViewModel = InitializeCreateOrderViewModel();
            return View("CreateOrder", orderListViewModel);
        }

        private CreateOrderViewModel InitializeCreateOrderViewModel()
        {
            CreateOrderViewModel orderListViewModel = new CreateOrderViewModel();
            OrderService orderService = new OrderService();
            List<VehicleModel> vehicleModels = orderService.GetVehicleModels();
            List<SelectListItem> vehicleModelSelectList = new List<SelectListItem>();
            foreach (VehicleModel vehicleModel in vehicleModels)
            {
                SelectListItem item = new SelectListItem();
                item.Value = vehicleModel.vehicleModelID.ToString();
                item.Text = vehicleModel.vehicleModelName;
                item.Selected = false;
                vehicleModelSelectList.Add(item);
            }
            orderListViewModel.ModelList = vehicleModelSelectList;
            return orderListViewModel;
        }

        public JsonResult GetOptions(string modelId)
        {
            OrderService orderService = new OrderService();
            List<VehicleOption> options = orderService.GetOptions(modelId);
            var jsonOptions = options.Select(x => new { OptionId = x.vehicleOptionID, OptionName = x.vehicleOptionName }).ToList();
            JsonResult optionResult = Json(new MultiSelectList(jsonOptions, "OptionId", "OptionName"), JsonRequestBehavior.AllowGet);
            return optionResult;
        }

        [AdminFilter]
        [ValidateAntiForgeryToken]
        [HeaderFooterFilter]
        public ActionResult Save(Order order, string BtnSubmit)
        {
            switch (BtnSubmit)
            {
                case "Save Order":
                    OrderService orderService = new OrderService();
                    if (ModelState.IsValid)
                    {
                        orderService.SaveOrder(order);
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        CreateOrderViewModel vm = InitializeCreateOrderViewModel();
                        vm.Vehicle = order.vehicle;
                        vm.Customer = order.customer;
                        vm.Requested = order.requested.ToString("M/d/yyyy");
                        vm.Built = order.built.ToString("M/d/yyyy");
                        return View("CreateOrder", vm);
                    }
                case "Cancel":
                    return RedirectToAction("Index");
            }
            return new EmptyResult();
        }

        [ChildActionOnly]
        public ActionResult GetAddNewLink()
        {
            if(Convert.ToBoolean(Session["IsAdmin"]))
            {
                return PartialView("AddNewLink");
            }
            else
            {
                return new EmptyResult();
            }
        }

    }
}