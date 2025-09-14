using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExaminationSystemEFCore
{
    public enum QuestionType
    {
        MultipleChoice, TrueFalse, Essay
    }
    public abstract class Question
    {
        public int ID { get; set; }
        public string QuestionText { get; set; }
        public decimal Marks { get; set; }
        public QuestionType QuestionType { get; set; }
        public DateTime CreatedDate { get; set; }
        public Exam Exam { get; set; }
        public int ExamID { get; set; }
        public ICollection<StudentAnswer> StudentAnswers { get; set; }


    }
}
