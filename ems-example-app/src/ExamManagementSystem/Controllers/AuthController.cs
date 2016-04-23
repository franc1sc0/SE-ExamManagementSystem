using System.Linq;
using Microsoft.AspNet.Mvc;
using Microsoft.AspNet.Mvc.Rendering;
using Microsoft.Data.Entity;
using ExamManagementSystem.Models;

namespace ExamManagementSystem.Controllers
{
    public class AuthController : Controller
    {
        private ExamManagementContext _context;

        public AuthController(ExamManagementContext context)
        {
            _context = context;    
        }

        // GET: Auth
        public IActionResult Index()
        {
            return View(_context.EMSUser.ToList());
        }

        // GET: Auth/Details/5
        public IActionResult Details(string id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            EMSUser eMSUser = _context.EMSUser.Single(m => m.Id == id);
            if (eMSUser == null)
            {
                return HttpNotFound();
            }

            return View(eMSUser);
        }

        // GET: Auth/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Auth/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(EMSUser eMSUser)
        {
            if (ModelState.IsValid)
            {
                _context.EMSUser.Add(eMSUser);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(eMSUser);
        }

        // GET: Auth/Edit/5
        public IActionResult Edit(string id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            EMSUser eMSUser = _context.EMSUser.Single(m => m.Id == id);
            if (eMSUser == null)
            {
                return HttpNotFound();
            }
            return View(eMSUser);
        }

        // POST: Auth/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(EMSUser eMSUser)
        {
            if (ModelState.IsValid)
            {
                _context.Update(eMSUser);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(eMSUser);
        }

        // GET: Auth/Delete/5
        [ActionName("Delete")]
        public IActionResult Delete(string id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            EMSUser eMSUser = _context.EMSUser.Single(m => m.Id == id);
            if (eMSUser == null)
            {
                return HttpNotFound();
            }

            return View(eMSUser);
        }

        // POST: Auth/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(string id)
        {
            EMSUser eMSUser = _context.EMSUser.Single(m => m.Id == id);
            _context.EMSUser.Remove(eMSUser);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
