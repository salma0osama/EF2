using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExaminationSystemEFCore
{
    public class Instructor
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Specialization { get; set; }
        public DateTime HireDate { get; set; }
        public bool IsActive { get; set; } = true;
        public ICollection<InstructorCourse> InstructorCourses { get; set; }
        public ICollection<Exam> Exams { get; set; } //= new List<Exam>();


    }
}
