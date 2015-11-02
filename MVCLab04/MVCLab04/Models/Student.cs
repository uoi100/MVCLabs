using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace MVCLab04.Models
{
    public class Student
    {
        [Required, StringLength(9), Display(Name = "A0080000")]
        public string StudentID { get; set; }

        [Required, StringLength(100), Display(Name = "FirstName")]
        public string FirstName { get; set; }

        [Required, StringLength(100), Display(Name = "LastName")]
        public string LastName { get; set; }

        [Required]
        public DateTime Birthday { get; set; }

        public virtual Program Program { get; set; }
        public virtual ICollection<CourseRegistration> CourseRegistrations { get; set; }
    }
}