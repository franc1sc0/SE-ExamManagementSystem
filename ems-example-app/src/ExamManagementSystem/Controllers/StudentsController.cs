using System.Linq;
using Microsoft.AspNet.Mvc;
using Microsoft.AspNet.Mvc.Rendering;
using Microsoft.Data.Entity;
using ExamManagementSystem.Models;
using Microsoft.AspNet.Authorization;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ExamManagementSystem.Controllers
{
    [Authorize (Roles="faculty")]
    public class StudentsController : Controller
    {
        private ExamManagementContext _context;
        private ExamManagementContextSeedData _seeder;

        public StudentsController(ExamManagementContext context, ExamManagementContextSeedData seeder)
        {
            _context = context;
            _seeder = seeder;
        }

        // GET: Students
        public IActionResult Index(string option, string search)
        {


            //ExamManagementContext emc = new ExamManagementContext();//whole context

            //var RegExam = emc.RegExam.Where(Re => Re.examID == examID);

            //List<RegExam> regExam = RegExam.ToList();
            //List<Student> studentList = _context.Students.ToList();
            //for (int x = 0; x < studentList.Count(); x++)
            //{
            //    var stud = emc.RegExam.Where(s => s.studentID == studentList[x].studentID);
            //    regExam[x].Student = studentList[x];
            //    //studentList.Add(stud.First());
            //}

            // Eww-wee! This is stinky.
            if (option=="firstName")
            {
                return View(_context.Students.Where(x => x.firstName.Contains(search) || search == null).ToList());
            }
            else if (option=="lastName")
            {
                return View(_context.Students.Where(x => x.lastName.Contains(search) || search == null).ToList());
            }
            else if (option == "username")
            {
                return View(_context.Students.Where(x => x.UserName.Contains(search) || search == null).ToList());
            }
            else if (option == "studentId")
            {
                return View(_context.Students.Where(x => x.txStateID.Contains(search) || search == null).ToList());
            }
            else if (option == "major")
            {
                return View(_context.Students.Where(x => x.major.Contains(search) || search == null).ToList());
            }
            else if (option == "email")
            {
                return View(_context.Students.Where(x => x.email.Contains(search) || search == null).ToList());
            }
            // Based on Groups
            else if (option == "exam")
            {
                return View(_context.Students.Where(x => x.group1.Contains(search) || x.group2.Contains(search) || x.group3.Contains(search) || x.group4.Contains(search) || search == null).ToList());
            }

            // No search match
            return View(_context.Students.ToList());
        }

        // GET: Students/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            Student student = _context.Students.Single(m => m.studentID == id);
            if (student == null)
            {
                return HttpNotFound();
            }

            return View(student);
        }

        // GET: Students/Create
        public IActionResult Create()
        {
            return View();
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Student student, string Password)
        {
            if (ModelState.IsValid)
            {
                _context.Students.Add(student);
                _context.SaveChanges();
                var result = await _seeder.CreateStudentIdentityUser(student, Password);
                if (result.Succeeded)
                {
                    return RedirectToAction("Index");
                }
            }
            return View(student);
        }

        // GET: Students/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            Student student = _context.Students.Single(m => m.studentID == id);
            if (student == null)
            {
                return HttpNotFound();
            }
            return View(student);
        }

        // POST: Students/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Student student)
        {
            if (ModelState.IsValid)
            {
                _context.Update(student);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(student);
        }

        // GET: Students/Delete/5
        [ActionName("Delete")]
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            Student student = _context.Students.Single(m => m.studentID == id);
            if (student == null)
            {
                return HttpNotFound();
            }

            return View(student);
        }

        // POST: Students/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            Student student = _context.Students.Single(m => m.studentID == id);
            _context.Students.Remove(student);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
