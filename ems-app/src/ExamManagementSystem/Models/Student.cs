using Microsoft.AspNet.Mvc;
using System.ComponentModel.DataAnnotations;

namespace ExamManagementSystem.Models
{
    public class Student
    {
        [HiddenInput(DisplayValue = false)]
        public int StudentId { get; set; }
        [Display(Name = "First Name")]
        public string FirstName { get; set; }
        [Display(Name = "Last Name")]
        public string LastName { get; set; }
        [Display(Name = "Major")]
        public string Major { get; set; }
        [Display(Name = "Email")]
        public string Email { get; set; }
        [Display(Name = "Username")]
        public string UserName { get; set; }
    }
}
