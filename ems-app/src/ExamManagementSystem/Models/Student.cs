using Microsoft.AspNet.Mvc;
using System.ComponentModel.DataAnnotations;

namespace ExamManagementSystem.Models
{
    public class Student
    {
        [HiddenInput(DisplayValue = false)]
        public int studentID { get; set; }
        [Display(Name = "First Name")]
        public string firstName { get; set; }
        [Display(Name = "Last Name")]
        public string lastName { get; set; }
        [Display(Name = "Major")]
        public string major { get; set; }
        [Display(Name = "Email")]
        public string email { get; set; }
        [Display(Name = "Username")]
        public string UserName { get; set; }
    }
}
