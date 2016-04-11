using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ExamManagementSystem.Models
{
    public class ProductPurchasingContextSeedData
    {
        private ProductPurchasingContext _context;

        public ProductPurchasingContextSeedData(ProductPurchasingContext context)
        {
            _context = context;
        }

        public void EnsureSeedData()
        {
            if (!_context.Products.Any())
            {
                var product1 = new Product();
                product1.name = "Test1";
                product1.price = 100.00;
                product1.slug = "test1";
                product1.uuid = "abc-123";

                _context.Add(product1);
                _context.SaveChanges();
            }
        }


    }
}