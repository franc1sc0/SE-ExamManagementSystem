using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ExamManagementSystem.Models
{
    public class ExamManagementContextSeedData
    {
        private ExamManagementContext _context;

        public ExamManagementContextSeedData(ExamManagementContext context)
        {
            _context = context;
        }

        public void EnsureSeedData()
        {
            if (!_context.Faculty.Any())
            {
                var faculty1 = new Faculty();
                faculty1.Name = "Professor1";

                _context.Add(faculty1);
                _context.SaveChanges();
            }

            if (!_context.Students.Any())
            {
                var student1 = new Student();
                student1.Name = "Student1";

                _context.Add(student1);
                _context.SaveChanges();
            }

            if (!_context.Exams.Any())
            {
                var exam1 = new Exam();
                exam1.Name = "Exam1";

                _context.Add(exam1);
                _context.SaveChanges();
            }
        }
    }
}