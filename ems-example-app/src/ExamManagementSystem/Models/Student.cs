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
        public int studentID { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string txStateID { get; set; }
        public string major { get; set; }
        public string email { get; set; }

        public string UserName { get; set; }

        //public int UserIdFK { get; set; }
        //[ForeignKey("UserName")]
        //public EMSUser EMSUser { get; set; }
    }
}
