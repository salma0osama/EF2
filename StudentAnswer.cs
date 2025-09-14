using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExaminationSystemEFCore
{
    public class StudentAnswer
    {
        public int ID { get; set; }
        public string AnswerText { get; set; }
        public char? SelectedOption { get; set; }
        public bool? BooleanAnswer { get; set; }
        public decimal? MarksObtained { get; set; }
        public DateTime SubmittedAt { get; set; }
        public ExamAttempt ExamAttempt { get; set; }
        public int ExamAttemptID { get; set; }
        public Question Question { get; set; }
        public int QuestionId { get; set; }

    }
}
