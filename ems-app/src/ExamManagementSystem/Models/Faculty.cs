using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ExamManagementSystem.Models
{
    public class Faculty
    {
        public int FacultyId { get; set; }
        [Required]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }
        [Required]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }
        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }
        // this is how we map back to identity table
        [Required]
        [Display(Name = "User Name")]
        public string UserName { get; set; }
    }
}
