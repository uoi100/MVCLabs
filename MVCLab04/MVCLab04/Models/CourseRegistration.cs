using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace MVCLab04.Models
{
    public class CourseRegistration
    {
        [ScaffoldColumn(false)]
        public int CourseRegistrationID { get; set; }

        [Required]
        public int Grade { get; set; }

        public string StudentID { get; set; }
        public string CourseID { get; set; }

        public virtual Student Student { get; set; }
        public virtual Course Course { get; set; }
    }
}