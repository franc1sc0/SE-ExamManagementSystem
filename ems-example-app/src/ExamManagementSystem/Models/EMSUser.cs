using Microsoft.AspNet.Identity.EntityFramework;

namespace ExamManagementSystem.Models
{
    public class EMSUser : IdentityUser
    {
        public Faculty Faculty { get; set; }
        public Student Student { get; set; }
    }
}