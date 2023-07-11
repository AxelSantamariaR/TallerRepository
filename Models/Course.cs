using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Course
    {
        [Key]
        public int CourseId { get; set; }

        public string CourseName { get; set; }

        public List<StudentCourse> StudentCourse { get; set; }
    }
}
