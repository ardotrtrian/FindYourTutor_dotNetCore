using FYT.Models.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace FYT.Models
{
    public partial class Rating : EntityBase
    {
        public int CourseId { get; set; }

        public int StudentId { get; set; }

        public byte Rate { get; set; }
               
        public virtual Course Course { get; set; }

        public virtual User Student { get; set; }
    }
}
