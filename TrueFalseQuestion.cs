using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExaminationSystemEFCore
{
    public class TrueFalseQuestion :Question
    {
        public bool CorrectAnswer { get; set; }
    }
}
