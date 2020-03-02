﻿using FYT.Models.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace FYT.Models
{
    public class Comment : EntityBase
    {
        [Required]
        public virtual Course Course { get; set; }

        [Required]
        public virtual User Student { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public DateTime DateTime { get; set; }
    }
}