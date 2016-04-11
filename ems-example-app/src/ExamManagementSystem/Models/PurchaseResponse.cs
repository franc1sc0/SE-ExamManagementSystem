using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExamManagementSystem.Models
{
    public class PurchaseResponse
    {
        public string confirmation_code { get; set; }
        public ProductDetail product { get; set; }
        public int user_id { get; set; }
        public int quantity { get; set; }
    }
}
