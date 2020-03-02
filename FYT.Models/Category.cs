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
        public string Name { get; set; }
    }
}
