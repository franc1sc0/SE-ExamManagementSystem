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
        public string firstName { get; set; }
        public string lastName { get; set; }
        [Editable(false)]
        public string txStateID { get; set; }
        [Editable(false)]
        public string major { get; set; }
        [Editable(false)]
        [Display(Name = "Programming Result")]
        public string prgResult { get; set; }
        [Editable(false)]
        [Display(Name = "Communication Result")]
        public string commResult { get; set; }
        public string email { get; set; }
        public string phone { get; set; }
        public string address { get; set; }
        public string city { get; set; }
        public string zip { get; set; }
        // this is how we map back to identity table
        [Editable(false)]
        public string UserName { get; set; }

        public virtual ICollection<RegExam> RegExam { get; set; }
    }
}
