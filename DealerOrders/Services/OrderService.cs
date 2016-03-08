using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DealerOrders.Models;
using DealerOrders.Repositories;

namespace DealerOrders.Services
{
    public class OrderService
    {
        public List<Order> GetOrders()
        {
            VehicleOrderDbContext vehicleOrderDbContext = new VehicleOrderDbContext();
            return vehicleOrderDbContext.Orders.ToList();
        }

        public Order SaveOrder(Order o)
        {
            VehicleOrderDbContext vehicleOrderDbContext = new VehicleOrderDbContext();
            vehicleOrderDbContext.Orders.Add(o);
            vehicleOrderDbContext.SaveChanges();
            return o;
        }

        // TODO: compare to db table using db context instead of hard-coded values
        public UserStatus GetUserValidity(UserDetails u)
        {
            if(u.UserName == "Admin" && u.Password == "Admin")
            {
                return UserStatus.AuthenticatedAdmin;
            }
            else if (u.UserName == "Phillip" && u.Password == "Phillip")
            {
                return UserStatus.AuthenticatedUser;
            }
            else
            {
                return UserStatus.NonAuthentiatedUser;
            }
        }

        public void UploadOrders(List<Order> orders)
        {
            VehicleOrderDbContext vehicleOrderDbContext = new VehicleOrderDbContext();
            vehicleOrderDbContext.Orders.AddRange(orders);
            vehicleOrderDbContext.SaveChanges();
        }

        public List<VehicleModel> GetVehicleModels()
        {
            VehicleOrderDbContext vehicleOrderDbContext = new VehicleOrderDbContext();
            return vehicleOrderDbContext.VehicleModels.ToList();
        }

        public VehicleModel FindVehicleModel(string modelId)
        {
            VehicleOrderDbContext vehicleOrderDbContext = new VehicleOrderDbContext();
            Guid guidModelId = Guid.Parse(modelId);
            VehicleModel vehicleModel = vehicleOrderDbContext.VehicleModels.Find(guidModelId);
            return vehicleModel;
        }

        internal List<VehicleOption> GetOptions(string modelId)
        {
            VehicleOrderDbContext vehicleOrderDbContext = new VehicleOrderDbContext();
            VehicleModel vehicleModel = FindVehicleModel(modelId);
            return vehicleModel.vehicleOptions.ToList();
        }
    }
}