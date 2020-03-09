using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using FYT.Models.Base;

namespace FYT.Models
{
    public partial class Course : EntityBase
    {
        [Required]
        [Display(Name = "Course Name")]
        [StringLength(25)]
        public string Name { get; set; }

        public int TutorId { get; set; }

        [ForeignKey("TutorId")]
        public User Tutor { get; set; }

        public int CategoryId { get; set; }

        [ForeignKey("CategoryId")]
        public virtual Category Category { get; set; }

        [Required]
        public DateTime StartDate { get; set; }

        [Required]
        public DateTime EndDate { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public double Price { get; set; }

        public virtual ICollection<Comment> Comments { get; set; }

        public virtual ICollection<Rating> Ratings { get; set; }
    }
}
