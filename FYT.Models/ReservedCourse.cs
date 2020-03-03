using FYT.Models.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace FYT.Models
{
    public partial class ReservedCourse : EntityBase
    {
        [Required]
        public virtual Course Course { get; set; }

        [Required]
        public User Student { get; set; }

        [Required]
        public Status Status { get; set; }
    }
}
