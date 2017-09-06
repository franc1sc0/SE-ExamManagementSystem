using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ExamManagementSystem.Models
{
    public class Faculty
    {
        public int facultyID { get; set; }
        [Required]
        [Display(Name = "First Name")]
        public string firstName { get; set; }
        [Required]
        [Display(Name = "Last Name")]
        public string lastName { get; set; }
        [Required]
        [Display(Name = "Email")]
        public string email { get; set; }
        // this is how we map back to identity table
        [Required]
        [Display(Name = "User Name")]
        public string UserName { get; set; }
    }
}
