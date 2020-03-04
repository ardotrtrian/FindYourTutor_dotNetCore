using FYT.DataAccess.Data.Repository.IRepository;
using FYT.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FYT.DataAccess.Data.Repository
{
    class CourseRepository : Repository<Course> , ICourseRepository 
    {
        private readonly ApplicationDbContext _db;

        public CourseRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public IEnumerable<Course> GetAll(int tutorId)
        {
            return _db.Course.Where(c => c.TutorId == tutorId); 
        }

        public void Update(Course course)
        {
            var objFromDb = _db.Course.FirstOrDefault(c => c.Id == course.Id);

            objFromDb.Name = course.Name;
            objFromDb.Category = course.Category;
            objFromDb.Description = course.Description;
            objFromDb.StartDate = course.EndDate;

            _db.SaveChanges();
        }
    }
}
