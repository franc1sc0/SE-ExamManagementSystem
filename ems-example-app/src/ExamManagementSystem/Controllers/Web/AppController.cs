using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using ExamManagementSystem.Models;

namespace ExamManagementSystem.Controllers.Web
{
    public class AppController : Controller
    {
        private ProductPurchasingContext _context;

        public AppController(ProductPurchasingContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Products()
        {
            var products = _context.Products.OrderBy(t => t.name).ToList();
            return View(products);
        }

        [HttpGet("app/products/{id}")]
        public IActionResult Details(int id)
        {
            ProductDetail productDetail = new ProductDetail();
            return View(productDetail);
        }

        public IActionResult Purchase()
        {
            return View();
        }
    }
}
