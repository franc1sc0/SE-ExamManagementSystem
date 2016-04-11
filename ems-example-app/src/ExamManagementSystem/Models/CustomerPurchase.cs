using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ExamManagementSystem.Models
{
    public class CustomerPurchase
    {
        [Required]
        [Display(Name = "Email")]
        public string customer_email { get; set; }

        [Required]
        [Display(Name = "Name")]
        public string customer_name { get; set; }
        
        [Required(ErrorMessage = "Your must provide a Phone Number")]
        [Display(Name = "Phone")]
        [DataType(DataType.PhoneNumber)]
        [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$", ErrorMessage = "Not a valid Phone number")]
        public string customer_phone { get; set; }

        [Required]
        [Display(Name = "Quantity")]
        public int quantity { get; set; }
    }
}
