using System;
using System.Collections.Generic;
using System.Text;
using FYT.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace FYT.DataAccess.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Category> Category { get; set; }
        public DbSet<User> User { get; set; }
        public DbSet<Image> Image { get; set; }
        public DbSet<Comment> Comment { get; set; }
        public DbSet<ReservedCourse> ReservedCourses { get; set; }
        public DbSet<Course> Course { get; set; }
        public DbSet<Rating> Rating { get; set; }

    }
}
