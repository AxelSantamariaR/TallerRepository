using Microsoft.EntityFrameworkCore;
using Models;
using System.Collections.Generic;

namespace ConsoleApp.Context
{
    public class StudentContext : DbContext
    {

        public StudentContext(DbContextOptions<StudentContext> options) : base(options) { }

        public DbSet<Student> Students { get; set; }

        public DbSet<Course> Courses { get; set; }

        public DbSet<StudentAddress> StudentAddresses { get; set; }

        public DbSet<StudentCourse> StudentCourses { get; set; }

    }
}
