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
                var newUser = new EMSUser()
                {
                    UserName = "faculty1",
                    Email = "faculty1@txstate.edu"
                };

                var result = await _userManager.CreateAsync(newUser, PASSWORD);
                if (result.Succeeded)
                {
                    var createdUser = await _userManager.FindByNameAsync(newUser.UserName);
                    await _userManager.AddToRoleAsync(createdUser, facultyRole);
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
                var newUser = new EMSUser()
                {
                    UserName = "student1",
                    Email = "student1@txstate.edu"
                };

                var result = await _userManager.CreateAsync(newUser, PASSWORD);
                if (result.Succeeded)
                {
                    var createdUser = await _userManager.FindByNameAsync(newUser.UserName);
                    await _userManager.AddToRoleAsync(createdUser, studentRole);
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
            }

            if (!_context.Exams.Any())
            {
                //var exam1 = new Exam();
                //exam1.Name = "Exam1";

                //_context.Add(exam1);
                //_context.SaveChanges();
            }
        }
    }
}