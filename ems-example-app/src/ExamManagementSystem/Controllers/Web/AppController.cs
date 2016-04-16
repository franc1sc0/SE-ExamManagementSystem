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
        private ExamManagementContext _context;

        public AppController(ExamManagementContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
