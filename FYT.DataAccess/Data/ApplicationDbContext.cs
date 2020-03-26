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

        public ApplicationDbContext()
        {

        }


        public DbSet<Category> Category { get; set; }
        public DbSet<User> User { get; set; }
        public DbSet<Comment> Comment { get; set; }
        public DbSet<ReservedCourse> ReservedCourse { get; set; }
        public DbSet<Course> Course { get; set; }
        public DbSet<Rating> Rating { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Category>()
                .Property(e => e.Timestamp)
                .IsFixedLength();

            modelBuilder.Entity<Category>()
                .HasMany(e => e.Course)
                .WithOne(e => e.Category)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Comment>()
                .Property(e => e.Timestamp)
                .IsFixedLength();

            modelBuilder.Entity<Course>()
                .Property(e => e.Price)
                .IsRequired();
            
            modelBuilder.Entity<Course>()
                .Property(e => e.Timestamp)
                .IsFixedLength();

            modelBuilder.Entity<Course>()
                .HasMany(e => e.Comment)
                .WithOne(e => e.Course)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Course>()
                .HasMany(e => e.Rating)
                .WithOne(e => e.Course)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Course>()
               .HasMany(e => e.ReservedCourse)
               .WithOne(e => e.Course)
               .IsRequired()
               .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Rating>()
                .Property(e => e.Timestamp)
                .IsFixedLength();

            modelBuilder.Entity<ReservedCourse>()
                .Property(e => e.Timestamp)
                .IsFixedLength();

            modelBuilder.Entity<User>()
                .Property(e => e.Timestamp)
                .IsFixedLength();

            modelBuilder.Entity<User>()
                .HasMany(e => e.Comment)
                .WithOne(e => e.User)
                .IsRequired()
                .HasForeignKey(e => e.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<User>()
               .HasMany(e => e.Course)
               .WithOne(e => e.Tutor)
               .IsRequired()
               .HasForeignKey(e => e.TutorId)
               .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<User>()
                .HasMany(e => e.Rating)
                .WithOne(e => e.Student)
                .IsRequired()
                .HasForeignKey(e => e.StudentId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<User>()
                .HasMany(e => e.ReservedCourse)
                .WithOne(e => e.Student)
                .IsRequired()
                .HasForeignKey(e => e.StudentId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
