using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExaminationSystemEFCore
{
    public class Exam
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public decimal TotalMarks { get; set; }
        public TimeSpan Duration { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public bool IsActive { get; set; } = true;
        public Course Course { get; set; } 
        public int CourseID { get; set; }
        public Instructor Instructor { get; set; }
        public int InstructorId { get; set; }

        public ICollection<ExamAttempt> ExamAttempts { get; set; }
        public ICollection<Question> Questions { get; set; }


    }
}
