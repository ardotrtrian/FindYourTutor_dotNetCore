using FYT.Models.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace FYT.Models
{
    public partial class Rating : EntityBase
    {
        [Required]
        public virtual Course Course { get; set; }

        [Required]
        public virtual User Student { get; set; }

        [Required]
        public byte Rate { get; set; }
    }
}
