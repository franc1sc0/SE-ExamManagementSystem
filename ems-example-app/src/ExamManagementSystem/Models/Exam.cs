using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ExamManagementSystem.Models
{
    public class Exam
    {
        [ScaffoldColumn(false)]
        public int examID { get; set; }
        public string examType { get; set; }
        public DateTime date { get; set; }
        [Display(Name = "Start Time")]
        public DateTime startTime { get; set; }
        [Display(Name = "End Time")]
        public DateTime endTime { get; set; }
        [Display(Name = "Registration Deadline")]
        public DateTime regDeadline { get; set; }
        public string semester { get; set; }
        public string location { get; set; }


       // [ScaffoldColumn(false)]
       // public int studentID { get; set; }
    }
}
