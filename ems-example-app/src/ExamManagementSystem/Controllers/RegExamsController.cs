using System.Linq;
using Microsoft.AspNet.Mvc;
using Microsoft.AspNet.Mvc.Rendering;
using Microsoft.Data.Entity;
using ExamManagementSystem.Models;

namespace ExamManagementSystem.Controllers
{
    public class RegExamsController : Controller
    {
        private ExamManagementContext _context;

        public RegExamsController(ExamManagementContext context)
        {
            _context = context;    
        }

        // GET: RegExams
        public IActionResult Index()
        {
            return View(_context.RegExam.ToList());
        }

        // GET: RegExams/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            RegExam regExam = _context.RegExam.Single(m => m.regExamID == id);
            if (regExam == null)
            {
                return HttpNotFound();
            }

            return View(regExam);
        }

        // GET: RegExams/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: RegExams/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(RegExam regExam)
        {
            if (ModelState.IsValid)
            {
                _context.RegExam.Add(regExam);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(regExam);
        }

        // GET: RegExams/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            RegExam regExam = _context.RegExam.Single(m => m.regExamID == id);
            if (regExam == null)
            {
                return HttpNotFound();
            }
            return View(regExam);
        }

        // POST: RegExams/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(RegExam regExam)
        {
            if (ModelState.IsValid)
            {
                _context.Update(regExam);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(regExam);
        }

        // GET: RegExams/Delete/5
        [ActionName("Delete")]
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            RegExam regExam = _context.RegExam.Single(m => m.regExamID == id);
            if (regExam == null)
            {
                return HttpNotFound();
            }

            return View(regExam);
        }

        // POST: RegExams/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            RegExam regExam = _context.RegExam.Single(m => m.regExamID == id);
            _context.RegExam.Remove(regExam);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
