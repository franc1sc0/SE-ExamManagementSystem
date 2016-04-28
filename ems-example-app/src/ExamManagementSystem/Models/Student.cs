using Microsoft.AspNet.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

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
        [Editable(false)]
        [Display(Name = "txstateid")]
        public string txStateID { get; set; }
        [Editable(false)]
        [Display(Name = "Major")]
        public string major { get; set; }
        [Editable(false)]
        [Display(Name = "Programming Result")]
        public string prgResult { get; set; }
        [Editable(false)]
        [Display(Name = "Communication Result")]
        public string commResult { get; set; }
        [Display(Name = "Group 1")]
        public string group1 { get; set; }
        [Display(Name = "Group 2")]
        public string group2 { get; set; }
        [Display(Name = "Group 3")]
        public string group3 { get; set; }
        [Display(Name = "Group 4")]
        public string group4 { get; set; }
        [Display(Name = "Email")]
        public string email { get; set; }
        [Display(Name = "Phone")]
        public string phone { get; set; }
        [Display(Name = "Address")]
        public string address { get; set; }
        [Display(Name = "City")]
        public string city { get; set; }
        [Display(Name = "Zip Code")]
        public string zip { get; set; }
        // this is how we map back to identity table
        [Display(Name = "Username")]
        public string UserName { get; set; }

        public virtual ICollection<RegExam> RegExam { get; set; }
    }
}
