using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace DealerOrders.Models
{
    public class VehicleOption
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public Guid vehicleOptionID { get; set; }
        // foreign key association by convention instead of configuration (<classname>ID)
        public Guid vehicleModelID { get; set; }
        public virtual VehicleModel vehicleModel { get; set; }
        [Required]
        [StringLength(50, ErrorMessage = "Please Add Vehicle Option Name", MinimumLength = 2)]
        public string vehicleOptionName { get; set; }
    }
}