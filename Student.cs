using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExaminationSystemEFCore
{
    public class Student
    {
        public int ID { get; set; }
        public string Name { get; set; }
        [EmailAddress]
        public string Email { get; set; }
        public string StudentNumber { get; set; }
        public DateTime EnrollmentDate { get; set; }
        public bool IsActive { get; set; } = true;
        public ICollection<StudentCourse> StudentCourses { get; set; }
        public ICollection<ExamAttempt> ExamAttempts { get; set; }
    }
}
