using FYT.Models.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace FYT.Models
{
    public partial class Comment : EntityBase
    {
        public int CourseId { get; set; }

        public int UserId { get; set; }

        [Required]
        public string Description { get; set; }

        public DateTime CreationDateTime { get; set; }
                
        public virtual Course Course { get; set; }

        public virtual User User { get; set; }
    }
}
