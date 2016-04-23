using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ExamManagementSystem.Models
{
    public class RegExam
    {

        //This is what we call the Intermidiate/bridge/helper table.
        [ScaffoldColumn(false)]
        public int regExamID { get; set; }

        public string result { get; set; }
        public string score { get; set; }
        public string withdraw { get; set; }


        [ScaffoldColumn(false)]
        public int examID { get; set; }
    }
}
