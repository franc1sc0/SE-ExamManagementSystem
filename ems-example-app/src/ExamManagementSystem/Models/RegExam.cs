﻿using Microsoft.AspNet.Mvc;
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
        [HiddenInput(DisplayValue = false)]
        public int regExamID { get; set; }
        [Display(Name = "Result")]
        public string result { get; set; }
        [Display(Name = "Score")]
        public string score { get; set; }
        [Display(Name = "Withdraw")]
        public string withdraw { get; set; }
        public string publish { get; set; }
        public string registered { get; set; }
        [ScaffoldColumn(false)]
        //foregin key

        public int examID { get; set; }
        public int studentID { get; set; }
        public virtual Exam Exam { get; set; }
        public virtual Student Student { get; set; }
    }
}
