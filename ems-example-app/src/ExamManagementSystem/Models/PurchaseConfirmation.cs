using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamManagementSystem.Models
{
    public class PurchaseConfirmation
    {
        public int Id { get; set; }
        [Display(Name = "Confirmation Code")]
        public string confirmation_code { get; set; }
        [Display(Name = "Product Name")]
        public string product_name { get; set; }
        [Display(Name = "Price")]
        public double product_price { get; set; }
        [Display(Name = "Name")]
        public string customer_name { get; set; }
        [Display(Name = "Email Address")]
        public string customer_email_address { get; set; }
        [Display(Name = "Phone Number")]
        public string customer_phone_number { get; set; }
    }
}
