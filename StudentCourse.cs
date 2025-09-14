using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExaminationSystemEFCore
{
    public class StudentCourse
    {
        public Student Student { get; set; }
        public int StudentID { get; set; }
        public Course Course { get; set; }
        public int CourseID { get; set; }
        public DateTime EnrollmentDate { get; set; }
        public decimal? Grade { get; set; }
        public bool IsCompleted { get; set; } = false;

    }
}
