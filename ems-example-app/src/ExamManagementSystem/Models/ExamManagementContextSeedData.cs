using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ExamManagementSystem.Models
{
    public class ExamManagementContextSeedData
    {
        private ExamManagementContext _context;
        private RoleManager<IdentityRole> _roleManager;
        private UserManager<EMSUser> _userManager;

        public ExamManagementContextSeedData(ExamManagementContext context, UserManager<EMSUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _context = context;
            _userManager = userManager;
            _roleManager = roleManager;
        }

        string PASSWORD = "P@ssw0rd!";
        string facultyRole = "faculty";
        string studentRole = "student";
        public async Task EnsureSeedDataAsync()
        {
            if (await _roleManager.FindByNameAsync(facultyRole) == null)
            {
                var newRole = new IdentityRole(facultyRole);
                await _roleManager.CreateAsync(newRole);
            }

            if (await _roleManager.FindByNameAsync(studentRole) == null)
            {
                var newRole = new IdentityRole(studentRole);
                await _roleManager.CreateAsync(newRole);
            }

            if (!_context.Faculty.Any())
            {
                var userName = "faculty1";
                var emailDomain = "@txstate.edu";
                var newFaculty = new Faculty()
                {
                    UserName = userName,
                    email = userName + emailDomain
                };
                _context.Add(newFaculty);
                _context.SaveChanges();

                await CreateFacultyIdentityUser(newFaculty);
            }

            if (!_context.Students.Any())
            {
                var userName = "student1";
                var emailDomain = "@txstate.edu";
                var newStudent = new Student()
                {
                    major = "CS",
                    UserName = userName,
                    email = userName + emailDomain
                };
                _context.Add(newStudent);
                _context.SaveChanges();
                await CreateStudentIdentityUser(newStudent);

                var students = new List<Student>
                {
                new Student{txStateID="A04612323",UserName="c_a11",firstName="Carson",lastName="Alexander",major="ComputerScience",email="c_a11@txstate.edu",phone="817-238-7222",address="123 Exchange Dr",city="Austin",zip="78754"},
                new Student{txStateID="A05865234",UserName="a_m11",firstName="Meredith",lastName="Alonso",major="SoftwareEngineering",email="a_m72@txstate.edu",phone="235-457-7121",address="66 Crosspark Rd",city="Austin",zip="78724"},
                new Student{txStateID="A03477189",UserName="a_a11",firstName="Arturo",lastName="Anand",major="ComputerScience",email="a_a45@txstate.edu",phone="273464341",address="1873 Crosspark Rd",city="Austin",zip="78724"}
                };
                students.ForEach(s => _context.Students.Add(s));
                _context.SaveChanges();

                foreach (var student in students)
                {
                    var result = await CreateStudentIdentityUser(student);
                    if (!result.Succeeded)
                    {
                        throw new Exception("CreateStudentIdentity - Failed");
                    }
                }

            }

            if (!_context.Exams.Any())
            {
                var exams = new List<Exam>
                {
                new Exam{examType="Programming Exam",date=DateTime.Parse("2016-09-01"),startTime=TimeSpan.Parse("13:00:00"),endTime=TimeSpan.Parse("15:00:00"),regDeadline=DateTime.Parse("2016-08-25"),semester="Fall",location="SanMarcos"},
                new Exam{examType="Communication Exam",date=DateTime.Parse("2016-09-15"),startTime=TimeSpan.Parse("13:00:00"),endTime=TimeSpan.Parse("15:00:00"),regDeadline=DateTime.Parse("2016-09-10"),semester="Fall",location="SanMarcos"},
                new Exam{examType="Programming Exam",date=DateTime.Parse("2017-01-20"),startTime=TimeSpan.Parse("13:00:00"),endTime=TimeSpan.Parse("15:00:00"),regDeadline=DateTime.Parse("2016-08-25"),semester="Spring",location="SanMarcos"},
                new Exam{examType="Communication Exam",date=DateTime.Parse("2016-01-27"),startTime=TimeSpan.Parse("13:00:00"),endTime=TimeSpan.Parse("15:00:00"),regDeadline=DateTime.Parse("2016-09-10"),semester="Spring",location="SanMarcos"},
                };
                exams.ForEach(s => _context.Exams.Add(s));
                _context.SaveChanges();

            }
        }

        public async Task<IdentityResult> CreateFacultyIdentityUser(Faculty faculty)
        {
            IdentityResult iResult = new IdentityResult();
            if (await _userManager.FindByNameAsync(faculty.UserName) == null)
            {
                 
                var newUser = new EMSUser()
                {
                    UserName = faculty.UserName,
                    Email = faculty.email,
                };

                var result = await _userManager.CreateAsync(newUser, PASSWORD);
                if (result.Succeeded)
                {
                    var createdUser = await _userManager.FindByNameAsync(newUser.UserName);
                    iResult = await _userManager.AddToRoleAsync(createdUser, facultyRole);
                }
            }
            return iResult;
        }

        public async Task<IdentityResult> CreateStudentIdentityUser(Student student)
        {
            IdentityResult iResult = new IdentityResult();
            if (await _userManager.FindByNameAsync(student.UserName) == null)
            {
                var newUser = new EMSUser()
                {
                    UserName = student.UserName,
                    Email = student.email,
                };

                var result = await _userManager.CreateAsync(newUser, PASSWORD);
                if (result.Succeeded)
                {
                    var createdUser = await _userManager.FindByNameAsync(newUser.UserName);
                    iResult = await _userManager.AddToRoleAsync(createdUser, studentRole);
                }
            }
            return iResult;
        }
    }
}