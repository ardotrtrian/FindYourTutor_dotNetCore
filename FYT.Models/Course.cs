using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace FYT.Models
{
    class Course
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Display(Name = "Course Name")]
        public string Name { get; set; }

        [Required]
        public int CategoryId { get; set; }

        [Required]
        public int TutorId { get; set; }
    }
}
