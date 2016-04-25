using System.Linq;
using Microsoft.AspNet.Mvc;
using Microsoft.AspNet.Mvc.Rendering;
using Microsoft.Data.Entity;
using ExamManagementSystem.Models;
using System.Collections.Generic;
using System;

namespace ExamManagementSystem.Controllers
{
    public class ExamsController : Controller
    {
        private ExamManagementContext _context;

        public ExamsController(ExamManagementContext context)
        {
            _context = context;    
        }

        // GET: Exams
        public IActionResult Index()
        {
            return View(_context.Exams.ToList());
        }

        // GET: Exams/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            Exam exam = _context.Exams.Single(m => m.examID == id);
            if (exam == null)
            {
                return HttpNotFound();
            }

            return View(exam);
        }

        // GET: Exams/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Exams/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Exam exam)
        {
            if (ModelState.IsValid)
            {
                _context.Exams.Add(exam);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(exam);
        }

        // GET: Exams/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            Exam exam = _context.Exams.Single(m => m.examID == id);
            if (exam == null)
            {
                return HttpNotFound();
            }
            return View(exam);
        }

        // POST: Exams/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Exam exam)
        {
            if (ModelState.IsValid)
            {
                _context.Update(exam);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(exam);
        }
        public IActionResult ViewRegistered(int examID)
        {

            ExamManagementContext emc = new ExamManagementContext();//whole context

            var RegExam = emc.RegExam.Where(Re => Re.examID == examID);

            List<RegExam> regExam = RegExam.ToList();
            List<Student> studentList = new List<Student>();
            for(int x = 0; x < RegExam.Count(); x++)
            {
                var stud = emc.Students.Where(s => s.studentID == regExam[x].studentID);
                regExam[x].Student=stud.First();
                //studentList.Add(stud.First());
            }


            return View(regExam);
        }

        public IActionResult EnterResults(int examID)
        {

            ExamManagementContext emc = new ExamManagementContext();//whole context

            var RegExam = emc.RegExam.Where(Re => Re.examID == examID);

            List<RegExam> regExam = RegExam.ToList();
            List<Student> studentList = new List<Student>();
            for (int x = 0; x < RegExam.Count(); x++)
            {
                var stud = emc.Students.Where(s => s.studentID == regExam[x].studentID);
                regExam[x].Student = stud.First();
                //studentList.Add(stud.First());
            }


            return View(regExam);
        }

        [HttpPost]
        public IActionResult Submit(string val,string id)
        {

            ExamManagementContext emc = new ExamManagementContext();//whole context

            var regEList = emc.RegExam.Where(e => e.regExamID == Int32.Parse(id));

            if (regEList != null)
            {
                var firstR = regEList.First();
                firstR.result = val;

                emc.Update(firstR);
                // var regExam = new List<RegExam>();
                emc.SaveChanges();
            }
            return View("Index");
        }
        // GET: Exams/Delete/5
        [ActionName("Delete")]
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            Exam exam = _context.Exams.Single(m => m.examID == id);
            if (exam == null)
            {
                return HttpNotFound();
            }

            return View(exam);
        }

        // POST: Exams/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            Exam exam = _context.Exams.Single(m => m.examID == id);
            _context.Exams.Remove(exam);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
