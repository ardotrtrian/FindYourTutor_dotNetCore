using FYT.DataAccess.Data.Repository.IRepository;
using FYT.Models;
using Microsoft.EntityFrameworkCore;
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

        public new Course Get(int id)
        {
            return _db.Course.Include(c => c.Category).Include(c => c.Tutor).FirstOrDefault(c => c.Id == id);
        }

        public IEnumerable<Course> GetAll(int tutorId)
        {  
            var courses = _db.Course.Include(c => c.Category).Include(c => c.Tutor);
            return courses.Where(c => c.TutorId == tutorId); 
        }

        public IEnumerable<Course> GetAll()
        {
            return _db.Course.Include(c => c.Category).Include(c => c.Tutor);
        }
        

        public bool Update(Course course)
        {
            var objFromDb = _db.Course.FirstOrDefault(c => c.Id == course.Id);

            if (objFromDb == null)
            {
                return false;
            }
            objFromDb.Name = course.Name;
            objFromDb.Category = course.Category;
            objFromDb.Description = course.Description;
            objFromDb.StartDate = course.StartDate;
            objFromDb.EndDate = course.EndDate;
            objFromDb.Price = course.Price;



            _db.SaveChanges();
            return true;
        }
    }
}
