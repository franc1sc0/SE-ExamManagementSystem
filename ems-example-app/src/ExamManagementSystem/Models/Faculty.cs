using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ExamManagementSystem.Models
{
    public class Faculty
    {
        public int facultyID { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string email { get; set; }
        // this is how we map back to identity table
        public string UserName { get; set; }
    }
}
