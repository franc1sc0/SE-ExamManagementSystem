using System.Linq;
using Microsoft.AspNet.Mvc;
using Microsoft.AspNet.Mvc.Rendering;
using Microsoft.Data.Entity;
using ExamManagementSystem.Models;
using Microsoft.AspNet.Authorization;
using System.Threading.Tasks;

namespace ExamManagementSystem.Controllers
{
    [Authorize]
    public class FacultyController : Controller
    {
        private ExamManagementContext _context;
        private ExamManagementContextSeedData _seeder;

        public FacultyController(ExamManagementContext context, ExamManagementContextSeedData seeder)
        {
            _context = context;
            _seeder = seeder;
        }

        // GET: Faculty
        public IActionResult Index()
        {
            return View(_context.Faculty.ToList());
        }

        // GET: Faculty/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            Faculty faculty = _context.Faculty.Single(m => m.facultyID == id);
            if (faculty == null)
            {
                return HttpNotFound();
            }

            return View(faculty);
        }

        // GET: Faculty/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Faculty/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Faculty faculty)
        {
            if (ModelState.IsValid)
            {
                _context.Faculty.Add(faculty);
                _context.SaveChanges();
                var result = await _seeder.CreateFacultyIdentityUser(faculty);
                if (result.Succeeded)
                {
                    return RedirectToAction("Index");
                }
            }
            return View(faculty);
        }

        // GET: Faculty/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            Faculty faculty = _context.Faculty.Single(m => m.facultyID == id);
            if (faculty == null)
            {
                return HttpNotFound();
            }
            return View(faculty);
        }

        // POST: Faculty/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Faculty faculty)
        {
            if (ModelState.IsValid)
            {
                _context.Update(faculty);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(faculty);
        }

        // GET: Faculty/Delete/5
        [ActionName("Delete")]
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            Faculty faculty = _context.Faculty.Single(m => m.facultyID == id);
            if (faculty == null)
            {
                return HttpNotFound();
            }

            return View(faculty);
        }

        // POST: Faculty/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            Faculty faculty = _context.Faculty.Single(m => m.facultyID == id);
            _context.Faculty.Remove(faculty);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
