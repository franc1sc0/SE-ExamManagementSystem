using System;
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
        //GET: ViewCompleted
        public IActionResult ViewCompleted()
        {
            return View(_context.Students.Where(s=>s.prgResult == "Pass" && s.commResult == "Pass" && s.group1 == "Pass" && s.group2 == "Pass" && s.group3 == "Pass" && s.group4 == "Pass").ToList());

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

        public IActionResult ChangeResults(string option, string search)
        {            
            ExamManagementContext emc = new ExamManagementContext();//whole context
            List<Student> studList = null;
            if (option == "username")
            {
               studList = emc.Students.Where(s => s.UserName == search).ToList();
            }
            else if(option == "txstateId")
            {
                studList = emc.Students.Where(s => s.txStateID == search).ToList();
            }
            List<RegExam> regExamList = new List<RegExam>();
            if (studList == null || studList.Count == 0)
                return View(regExamList);

            var studentID = studList.First().studentID;
            regExamList = emc.RegExam.Where(e => e.studentID == studentID && (e.result!= null) && e.withdraw == "0").ToList();

            List<Exam> ExamObj = new List<Exam>();
            for (int x = 0; x < regExamList.Count(); x++)
            {
                var examTypes = emc.Exams.Where(c => c.examID == regExamList[x].examID);
                Exam temp = examTypes.First();
                ExamObj.Add(temp);
            }

            //Joining
            for (int x = 0; x < regExamList.Count(); x++)
            {
                regExamList[x].Exam = ExamObj[x];
            }
            return View(regExamList);
        }

        [HttpPost]
        public IActionResult UpdateResult(string result, string examRegistrationId, string studentID, string examinationID)
        {

            ExamManagementContext emc = new ExamManagementContext();//whole context

            var regEList = emc.RegExam.Where(e => e.regExamID == Int32.Parse(examRegistrationId));
            var studList = emc.Students.Where(s => s.studentID == Int32.Parse(studentID));
            var examList = emc.Exams.Where(ex => ex.examID == Int32.Parse(examinationID));

            if (regEList != null)
            {
                var firstR = regEList.First();
                firstR.result = result;

                emc.Update(firstR);
                // var regExam = new List<RegExam>();
                emc.SaveChanges();
            }
            var firstS = studList.First();
            
                var firstE = examList.First();
                if (firstE.examType == "Programming Exam")
                {
                    firstS.prgResult = result;
                }
                else if (firstE.examType == "Communication Exam")
                {
                    firstS.commResult = result;
                }

                emc.Update(firstS);
                emc.SaveChanges();


            return RedirectToAction("ChangeResults", "ExamRegistration", new { option = "txstateId", search = firstS.txStateID });               
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
