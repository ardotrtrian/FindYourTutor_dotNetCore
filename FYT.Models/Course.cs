using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using FYT.Models.Base;

namespace FYT.Models
{
    public partial class Course : EntityBase
    {
        [Required]
        [Display(Name = "Course Name")]
        public string Name { get; set; }

        [Required]
        public int CategoryId { get; set; }

        [Required]
        public int TutorId { get; set; }
    }
}
