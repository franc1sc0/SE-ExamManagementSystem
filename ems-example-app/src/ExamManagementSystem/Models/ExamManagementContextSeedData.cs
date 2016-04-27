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

        private const string PASSWORD = "P@ssw0rd!";
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
                    major = "Computer Science",
                    UserName = userName,
                    email = "mmouse" + emailDomain,
                    txStateID="A49583920",
                    firstName="Mickey",
                    lastName="Mouse",
                    group1 = "Pass",
                    group2 = "Pass",
                    group3 = "Pass",
                    group4 = "Pass",
                    phone = "235-385-9932",
                    address = "100 Congress",
                    city = "Austin",
                    zip = "78701"
                };
                _context.Add(newStudent);
                _context.SaveChanges();
                await CreateStudentIdentityUser(newStudent);

                var students = new List<Student>
                {
                new Student{txStateID="A04612323",UserName="c_a11",firstName="Carson",lastName="Alexander",major="ComputerScience",group1="Pass",group2="Pass",group3="Pass",group4="Pass",email="c_a11@txstate.edu",phone="817-238-7222",address="123 Exchange Dr",city="Austin",zip="78754"},
                new Student{txStateID="A05865234",UserName="a_m11",firstName="Meredith",lastName="Alonso",major="SoftwareEngineering",group1="Pass",group2="Pass",group3="Fail",email="a_m72@txstate.edu",phone="235-457-7121",address="66 Crosspark Rd",city="Austin",zip="78724"},
                new Student{txStateID="A03477189",UserName="a_a11",firstName="Arturo",lastName="Anand",major="ComputerScience",group1="Pass",group2="Pass",group3="Pass",group4="Pass",email="a_a45@txstate.edu",phone="273464341",address="1873 Crosspark Rd",city="Austin",zip="78724"}
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



            if (!_context.RegExam.Any())
            {
                var regExam = new List<RegExam>
               {
                   new RegExam {examID=1,result="pass",score="75",studentID=1,withdraw="0",publish="1",registered="1"},
                   new RegExam {examID=2,result="fail",score="66",studentID=1,withdraw="0",publish="1",registered="1"},
                   new RegExam {examID=3,studentID=1,withdraw="0",publish="0",registered="1" },
                   new RegExam {examID=2,result="fail",score="99",studentID=2,withdraw="0",publish="1",registered="1"}
               };
                regExam.ForEach(s => _context.RegExam.Add(s));
                _context.SaveChanges();
            }
        }

        public async Task<IdentityResult> CreateFacultyIdentityUser(Faculty faculty, string Password = PASSWORD)
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

        public async Task<IdentityResult> CreateStudentIdentityUser(Student student, string Password = PASSWORD)
        {
            IdentityResult iResult = new IdentityResult();
            if (await _userManager.FindByNameAsync(student.UserName) == null)
            {
                var newUser = new EMSUser()
                {
                    UserName = student.UserName,
                    Email = student.email,
                };

                var result = await _userManager.CreateAsync(newUser, Password);
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