using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Linq;
using System.Threading.Tasks;

namespace ExamManagementSystem.Models
{
    public class ExamManagementContextSeedData
    {
        private ExamManagementContext _context;
        private RoleManager<IdentityRole> _roleManager;
        private UserManager<EmsUser> _userManager;

        public ExamManagementContextSeedData(ExamManagementContext context, UserManager<EmsUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _context = context;
            _userManager = userManager;
            _roleManager = roleManager;
        }

        private const string Password = "password";
        string _facultyRole = "faculty";
        string _studentRole = "student";
        public async Task EnsureSeedDataAsync()
        {
            if (await _roleManager.FindByNameAsync(_facultyRole) == null)
            {
                var newRole = new IdentityRole(_facultyRole);
                await _roleManager.CreateAsync(newRole);
            }

            if (await _roleManager.FindByNameAsync(_studentRole) == null)
            {
                var newRole = new IdentityRole(_studentRole);
                await _roleManager.CreateAsync(newRole);
            }

            if (!_context.Faculty.Any())
            {
                var userName = "faculty";
                var emailDomain = "@university.edu";
                var newFaculty = new Faculty()
                {
                    UserName = userName,
                    Email = userName + emailDomain,
                    FirstName = "Root",
                    LastName = "Admin",        
                };
                _context.Add(newFaculty);
                _context.SaveChanges();

                await CreateFacultyIdentityUser(newFaculty);
            }

        }

        public async Task<IdentityResult> CreateFacultyIdentityUser(Faculty faculty, string password = Password)
        {
            IdentityResult iResult = new IdentityResult();
            if (await _userManager.FindByNameAsync(faculty.UserName) == null)
            {
                 
                var newUser = new EmsUser()
                {
                    UserName = faculty.UserName,
                    Email = faculty.Email,
                };

                var result = await _userManager.CreateAsync(newUser, ExamManagementContextSeedData.Password);
                if (result.Succeeded)
                {
                    var createdUser = await _userManager.FindByNameAsync(newUser.UserName);
                    iResult = await _userManager.AddToRoleAsync(createdUser, _facultyRole);
                }
            }
            return iResult;
        }

        public async Task<IdentityResult> CreateStudentIdentityUser(Student student, string password = Password)
        {
            IdentityResult iResult = new IdentityResult();
            if (await _userManager.FindByNameAsync(student.UserName) == null)
            {
                var newUser = new EmsUser()
                {
                    UserName = student.UserName,
                    Email = student.Email,
                };

                var result = await _userManager.CreateAsync(newUser, password);
                if (result.Succeeded)
                {
                    var createdUser = await _userManager.FindByNameAsync(newUser.UserName);
                    iResult = await _userManager.AddToRoleAsync(createdUser, _studentRole);
                }
            }
            return iResult;
        }
    }
}