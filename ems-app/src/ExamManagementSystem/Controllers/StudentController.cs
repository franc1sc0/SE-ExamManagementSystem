using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using Microsoft.AspNet.Mvc.Rendering;
using Microsoft.Data.Entity;
using ExamManagementSystem.Models;
using System.Collections.Generic;
using System;
using Microsoft.AspNet.Authorization;

namespace ExamManagementSystem.Controllers
{
    [Authorize(Roles = "student")]
    public class StudentController : Controller
    {
        private ExamManagementContext _context;

        public StudentController(ExamManagementContext context)
        {
            _context = context;    
        }
        
        /// GET: Student
        public IActionResult Index()
        {
            return View();
        }

        // GET: Student/Details/5
        public async Task<IActionResult> Details()
        {
            var currentUserName = User.Identity.Name; 
            Student student = await _context.Students.SingleAsync(m => m.UserName == currentUserName);
            if (student == null)
            {
                return HttpNotFound();
            }

            return View(student);
        }

        //public IActionResult ExamDetails(Exam exam)
        //{
        //    return View(exam);
        //}

        //public IActionResult AvailExams()
        //{
        //    var emc = new ExamManagementContext();
        //    var allExams = emc.Exams.ToList();
        //    var loggedStudent = emc.Students.Where(s => s.UserName == User.Identity.Name).First();
        //    var regExams = emc.RegExam.Where(e => e.studentID == loggedStudent.studentID).ToList();

        //    regExams.RemoveAll(w => w.withdraw == "1");

        //    var blockedExams = regExams.Select(e => e.Exam).ToList();
        //    var availExams = allExams.Except(blockedExams);

        //    return View(availExams);
        //}

        //// GET: Student/Create
        //public IActionResult Exams()
        //{
        //    var currentUserName = User.Identity.Name;//gets current username logged in 

        //    //ExamManagementContext emc = new ExamManagementContext();//whole context
        //    var emc = _context;
        //    var regExamList =  emc.RegExam.ToList();//grabbing all regExams in DB


        //   // Student s = new Student();

        //    //grab student record where userName == loggedin user name.
        //    var student =  emc.Students.Where(s => s.UserName == currentUserName);

           
            
        //    Student s1 = student.First();//grabs the first student return

        //    //-Grabs regExam record where studentID grabed from step above == regExamStudentID
        //    //-This might return multiple results because the student could be 
        //    // registered for multiple exams 
        //    var regEList = emc.RegExam.Where(e => e.studentID == s1.studentID);

            
        //    var regExam = new List<RegExam>();

        //    regExam = regEList.ToList();//place them in a list 


        //    //query Examtypes found on regExam
        //    List<Exam> ExamObj = new List<Exam>();
        //    for (int x = 0; x < regExam.Count(); x++) {
        //        var examTypes = emc.Exams.Where(c => c.examID == regExam[x].examID);
        //        Exam temp = examTypes.First();
        //        ExamObj.Add(temp);
        //    }

        //    //Joining
        //    for (int x = 0; x < regExam.Count(); x++)
        //    {
        //        regExam[x].Exam = ExamObj[x];
        //    }

        //    // Remove withdrawn exams
        //    regExam.RemoveAll(w => w.withdraw == "1");

        //        // Student student = await _context.Students.SingleAsync(m => m.UserName == currentUserName);
        //        if (student == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    //_context.RegExam.Include(r=>regExam);
        //    return View(regExam);
        //}

        //public IActionResult Register(Exam exam)
        //{
        //    var emc = new ExamManagementContext();
        //    var loggedStudent = emc.Students.Where(s => s.UserName == User.Identity.Name).First();
        //    var regExams = emc.RegExam.Where(e => e.studentID == loggedStudent.studentID).ToList();
        //    var matchedExam = regExams.Where(e => e.examID == exam.examID);
        //    RegExam updatedExam = new RegExam();
     
        //    if (matchedExam.Count() > 0)
        //    {
        //        updatedExam = matchedExam.First();   
        //        updatedExam.withdraw = "0";
        //    }
        //    else
        //    {
        //        updatedExam.examID = exam.examID;
        //        updatedExam.studentID = loggedStudent.studentID;
        //        updatedExam.registered = "1";
        //        updatedExam.publish = "0";
        //        updatedExam.withdraw = "0";
        //    }
        //    emc.Update(updatedExam);
        //    emc.SaveChanges();

        //    return RedirectToAction("AvailExams");
        //    }

        //public IActionResult Withdraw(string withdraw, RegExam regExam)
        //{
        //    //ExamManagementContext emc = new ExamManagementContext();//whole context
        //    var emc = _context;
        //    // var regEList = emc.RegExam.Where(e => e.regExamID == Int32.Parse(withdraw));

        //    regExam.withdraw = "1";

        //    /* if (regEList != null)
        //     {
        //         var firstR = regEList.First();
        //         firstR.withdraw = "1";

        //         emc.Update(firstR);
        //         // var regExam = new List<RegExam>();
        //         emc.SaveChanges(); */
        //    emc.Update(regExam);
        //    emc.SaveChanges();

        //    return RedirectToAction("Exams");
        //}


        // POST: Student/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Student student)
        {
            if (ModelState.IsValid)
            {
                _context.Students.Add(student);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(student);
        }

        // GET: Student/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            Student student = await _context.Students.SingleAsync(m => m.studentID == id);
            if (student == null)
            {
                return HttpNotFound();
            }
            return View(student);
        }

        // POST: Student/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Student student)
        {
            if (ModelState.IsValid)
            {
                _context.Update(student);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(student);
        }

        // GET: Student/Delete/5
        [ActionName("Delete")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            Student student = await _context.Students.SingleAsync(m => m.studentID == id);
            if (student == null)
            {
                return HttpNotFound();
            }

            return View(student);
        }

        // POST: Student/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            Student student = await _context.Students.SingleAsync(m => m.studentID == id);
            _context.Students.Remove(student);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }
    }
}
