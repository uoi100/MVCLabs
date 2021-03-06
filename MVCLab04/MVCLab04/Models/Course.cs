﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace MVCLab04.Models
{
    public class Course
    {
        [Required, StringLength(100), Display(Name = "Course ID")]
        public string CourseID { get; set; }

        [Required, StringLength(100), Display(Name = "Course Name")]
        public string CourseName { get; set; }

        [Required]
        public int CourseCredit { get; set; }

        public virtual ICollection<CourseRegistration> CourseRegistrations { get; set; }
    }
}
