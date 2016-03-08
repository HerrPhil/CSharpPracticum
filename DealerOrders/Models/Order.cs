using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using DealerOrders.Validations;

namespace DealerOrders.Models
{
    public class Order
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public Guid vehicleID { get; set; }
        //[Required(ErrorMessage ="Enter Vehicle")]
        [OrderValidation]
        [StringLength(50, ErrorMessage = "Please Add Vehicle Model Name", MinimumLength = 2)]
        public string vehicle { get; set; }
        [StringLength(100, ErrorMessage = "Options allowed to be 2 to 100 characters", MinimumLength = 2)]
        public string options { get; set; }
        [Required(ErrorMessage ="Enter Customer")]
        [StringLength(100, ErrorMessage = "Customer allowed to be 2 to 100 characters", MinimumLength = 2)]
        public string customer { get; set; }
        public DateTime requested { get; set; }
        public DateTime built { get; set; }
    }
}