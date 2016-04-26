using System.Linq;
using Microsoft.AspNet.Mvc;
using Microsoft.AspNet.Mvc.Rendering;
using Microsoft.Data.Entity;
using ExamManagementSystem.Models;
using Microsoft.AspNet.Authorization;
using System.Collections.Generic;


namespace ExamManagementSystem.Controllers
{
    [Authorize]
    public class ExamRegistrationController : Controller
    {
        private ExamManagementContext _context;

        public ExamRegistrationController(ExamManagementContext context)
        {
            _context = context;    
        }

        // GET: RegExams
        public IActionResult Index()
        {
            var examManagementContext = _context.RegExam.Include(r => r.Exam).Include(r => r.Student);
            return View(examManagementContext.ToList());
        }

        //GET: ViewAll
        public IActionResult ViewAll()
        {
            return View(_context.Students.ToList());

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

        public IActionResult ExamHistory(int? id)
        {
            ExamManagementContext emc = new ExamManagementContext();
            if (id == null)
            {
                return HttpNotFound();
            }

            var sregExam = emc.RegExam.Where(m => m.studentID == id);
            if (sregExam == null)
            {
                return HttpNotFound();
            }
            var regeExam = new List<RegExam>();

            regeExam = sregExam.ToList();//place them in a list 

            List<Exam> ExamObj = new List<Exam>();
            for (int x = 0; x < regeExam.Count(); x++)
            {
                var examTypes = emc.Exams.Where(c => c.examID == regeExam[x].examID);
                Exam temp = examTypes.First();
                ExamObj.Add(temp);
            }

            //Joining
            for (int x = 0; x < regeExam.Count(); x++)
            {
                regeExam[x].Exam = ExamObj[x];
            }


            return View(regeExam);
        }

        // GET: RegExams/Create
        public IActionResult Create()
        {
            ViewData["examID"] = new SelectList(_context.Exams, "examID", "Exam");
            ViewData["studentID"] = new SelectList(_context.Students, "studentID", "Student");
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
            ViewData["examID"] = new SelectList(_context.Exams, "examID", "Exam", regExam.examID);
            ViewData["studentID"] = new SelectList(_context.Students, "studentID", "Student", regExam.studentID);
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
            ViewData["examID"] = new SelectList(_context.Exams, "examID", "Exam", regExam.examID);
            ViewData["studentID"] = new SelectList(_context.Students, "studentID", "Student", regExam.studentID);
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
            ViewData["examID"] = new SelectList(_context.Exams, "examID", "Exam", regExam.examID);
            ViewData["studentID"] = new SelectList(_context.Students, "studentID", "Student", regExam.studentID);
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
