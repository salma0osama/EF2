using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExaminationSystemEFCore
{
    public class Course
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public decimal MaximumDegree { get; set; }
        public DateTime CreatedDate { get; set; }
        public bool IsActive { get; set; } = true;
        public ICollection<Exam> Exams { get; set; } = new List<Exam>();
        public ICollection<StudentCourse> StudentCourses { get; set; }
        public ICollection<InstructorCourse> InstructorCourses { get; set; }

    }
}
