using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExaminationSystemEFCore
{
    public class EssayQuestion : Question
    {
        public int? MaxWordCount { get; set; }
        public string GradingCriteria { get; set; }
    }
}
