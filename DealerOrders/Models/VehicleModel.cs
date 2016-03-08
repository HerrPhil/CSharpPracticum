using DealerOrders.Validations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace DealerOrders.Models
{
    public class VehicleModel
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public Guid vehicleModelID { get; set; }
        [Required]
        [StringLength(50,ErrorMessage = "Please Add Vehicle Model Name", MinimumLength = 2)]
        public string vehicleModelName { get; set; }
        public virtual ICollection<VehicleOption> vehicleOptions { get; set; }
    }
}