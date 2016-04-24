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

        public async Task EnsureSeedDataAsync()
        {
            string PASSWORD = "P@ssw0rd!";
            string facultyRole = "faculty";
            if (await _roleManager.FindByNameAsync(facultyRole) == null)
            {
                var newRole = new IdentityRole(facultyRole);
                await _roleManager.CreateAsync(newRole);
            }

            if (await _userManager.FindByEmailAsync("faculty1@txstate.edu") == null)
            {
                // add the user
                
                var userName = "faculty1";
                var emailDomain = "@txstate.edu";
                
                var newUser = new EMSUser()
                {
                    UserName = userName,
                    Email = userName + emailDomain,
                    //Faculty = newFaculty
                };

                var result = await _userManager.CreateAsync(newUser, PASSWORD);
                if (result.Succeeded)
                {
                    var createdUser = await _userManager.FindByNameAsync(newUser.UserName);
                    await _userManager.AddToRoleAsync(createdUser, facultyRole);
                    var newFaculty = new Faculty()
                    {
                        UserName = userName
                    };
                    _context.Add(newFaculty);
                    _context.SaveChanges();
                }
            }

            string studentRole = "student";
            if (await _roleManager.FindByNameAsync(studentRole) == null)
            {
                var newRole = new IdentityRole(studentRole);
                await _roleManager.CreateAsync(newRole);
            }
            if (await _userManager.FindByEmailAsync("student1@txstate.edu") == null)
            {
                // add the user
                var userName = "student1";
                var emailDomain = "@txstate.edu";
                
                var newUser = new EMSUser()
                {
                    UserName = userName,
                    Email = userName + emailDomain,
                };
                
                var result = await _userManager.CreateAsync(newUser, PASSWORD);
                if (result.Succeeded)
                {
                    var createdUser = await _userManager.FindByNameAsync(newUser.UserName);
                    await _userManager.AddToRoleAsync(createdUser, studentRole);
                    var newStudent = new Student()
                    {
                        major = "CS",
                        UserName = userName
                    };
                    _context.Add(newStudent);
                    _context.SaveChanges();
                }
            }

            if (!_context.Faculty.Any())
            {
                //var faculty1 = new Faculty();
                //faculty1.Name = "Professor1";

                //_context.Add(faculty1);
                //_context.SaveChanges();
            }

            if (!_context.Students.Any())
            {
                //var student1 = new Student();
                //student1.Name = "Student1";

                //_context.Add(student1);
                //_context.SaveChanges();

            

                var students = new List<Student>
                {
                new Student{txStateID="A04612323",UserName="c_a11",firstName="Carson",lastName="Alexander",major="ComputerScience",email="c_a11@txstate.edu",phone="817-238-7222",address="123 Exchange Dr",city="Austin",zip="78754"},
                new Student{txStateID="A05865234",UserName="a_m11",firstName="Meredith",lastName="Alonso",major="SoftwareEngineering",email="a_m72@txstate.edu",phone="235-457-7121",address="66 Crosspark Rd",city="Austin",zip="78724"},
                new Student{txStateID="A03477189",UserName="a_a11",firstName="Arturo",lastName="Anand",major="ComputerScience",email="a_a45@txstate.edu",phone="273464341",address="1873 Crosspark Rd",city="Austin",zip="78724"}
                };
                students.ForEach(s => _context.Students.Add(s));
                _context.SaveChanges();

            }

            if (!_context.Exams.Any())
            {
                //var exam1 = new Exam();
                //exam1.Name = "Exam1";

                //_context.Add(exam1);
                //_context.SaveChanges();
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
    }
}