using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Student
    {
        [Key]
        public int StudentId { get; set; }

        public string Name { get; set; }

        public string LastName { get; set; }

        public StudentAddress StudentAddress { get; set; }

        public List<StudentCourse> StudentCourse { get; set; }
    }
}
