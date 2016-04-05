using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamManagementSystem.Models
{
    public class ProductDetail : Product
    {
        [Display(Name = "Cost")]
        public double cost { get; set; }
        [Display(Name = "Inventory On Hand")]
        public int inventory_on_hand { get; set; }
        [Display(Name = "Description")]
        public string description { get; set; }
    }
}
