using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ExamManagementSystem.Models
{
    public class Product
    {
        public int Id { get; set; }
        [Display(Name = "Price")]
        public double price { get; set; }
        [Display(Name = "Slug")]
        public string slug { get; set; }
        [Display(Name = "Name")]
        public string name { get; set; }
        [Display(Name = "UUID")]
        public string uuid { get; set; }
    }
}
