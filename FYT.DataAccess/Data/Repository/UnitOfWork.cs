using FYT.DataAccess.Data.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Text;

namespace FYT.DataAccess.Data.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _db;

        public ICategoryRepository Category { get; private set; }

        public ICourseRepository Course { get; private set; }
               
        public ICommentRepository Comment { get; private set; }

        public IRatingRepository Rating { get; private set; }

        public IReservedCourseRepository ReservedCourse { get; private set; }

        public IUserRepository UserRepository { get; private set; }

        public UnitOfWork(ApplicationDbContext db)
        {
            _db = db;
            Category = new CategoryRepository(_db);
            Course = new CourseRepository(_db);
            Comment = new CommentRepository(_db);
            Rating = new RatingRepository(_db);
            ReservedCourse = new ReservedCourseRepository(_db);
            UserRepository = new UserRepository(_db);
        }

        public void Dispose()
        {
            _db.Dispose();
        }
        public void Save()
        {
            _db.SaveChanges();
        }
    }
}
