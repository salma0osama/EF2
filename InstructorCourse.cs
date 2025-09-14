using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExaminationSystemEFCore
{
    public class InstructorCourse
    {
        public Instructor Instructor { get; set; }
        public int InstructorID { get; set; }
        public Course Course { get; set; }
        public int CourseID { get; set; }
        public DateTime AssignedDate { get; set; }
        public bool IsActive { get; set; } = true;

    }
}
