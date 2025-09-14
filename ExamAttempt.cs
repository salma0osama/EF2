using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExaminationSystemEFCore
{
    public class ExamAttempt
    {
        public int ID { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime? EndTime { get; set; }
        public decimal? TotalScore { get; set; }
        public bool IsSubmitted { get; set; } = false;
        public bool IsGraded { get; set; } = false;
        public Student Student { get; set; }
        public int StudentID { get; set; }
        public Exam Exam { get; set; }
        public int ExamID { get; set; }

        public ICollection<StudentAnswer> StudentAnswers { get; set; }

    }
}
