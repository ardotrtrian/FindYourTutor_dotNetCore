using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using FYT.Models.Base;

namespace FYT.Models
{
    public partial class Category : EntityBase
    {     
        [Required]
        [StringLength(25)]
        public string Name { get; set; }

        public virtual ICollection<Course> Courses { get; set; }
    }
}
