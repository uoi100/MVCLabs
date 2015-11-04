using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;

namespace MVCLab04.Models
{
    public class SchoolContext : DbContext
    {
        public SchoolContext(): base("Calvin Truong School Lab04")
        {

        }

        public DbSet<Course> Courses { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Program> Programs { get; set; }
        public DbSet<CourseRegistration> CourseRegistrations { get; set; }
    }
}