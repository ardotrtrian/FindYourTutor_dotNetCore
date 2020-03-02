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
        public User Tutor { get; set; }

        [Required]
        public virtual Category Category { get; set; }

        [Required]
        public DateTime StartDate { get; set; }

        [Required]
        public DateTime EndDate { get; set; }

        [Required]
        public string Description { get; set; }

        public virtual ICollection<Comment> Comments { get; set; }

        public virtual ICollection<Rating> Ratings { get; set; }
    }
}
