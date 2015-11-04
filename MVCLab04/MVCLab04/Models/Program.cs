using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;

namespace MVCLab04.Models
{
    public class Program
    {
        [ScaffoldColumn(false)]
        public int ProgramID { get; set; }

        [Required, StringLength(100), Display(Name = "Name")]
        public string ProgramName { get; set; }

        public virtual ICollection<Student> Students { get; set; }
    }
}