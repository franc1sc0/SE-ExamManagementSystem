﻿using Microsoft.AspNet.Mvc;
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
        [HiddenInput(DisplayValue = false)]
        public int examID { get; set; }
        public string examType { get; set; }
        [Display(Name = "Exam Date")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime date { get; set; }
        [Display(Name = "Start Time")]
        public TimeSpan startTime { get; set; }
        [Display(Name = "End Time")]
        public TimeSpan endTime { get; set; }
        [Display(Name = "Registration Deadline")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime regDeadline { get; set; }
        public string semester { get; set; }
        public string location { get; set; }

        public virtual ICollection<RegExam> RegExam { get; set; }

        public static implicit operator Exam(List<Exam> v)
        {
            throw new NotImplementedException();
        }
    }
}
