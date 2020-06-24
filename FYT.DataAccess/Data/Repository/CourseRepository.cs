using FYT.DataAccess.Data.Repository.IRepository;
using FYT.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FYT.DataAccess.Data.Repository
{
    class CourseRepository : Repository<Course> , ICourseRepository 
    {
        private readonly ApplicationDbContext _db;

        public CourseRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public new async Task<Course> GetAsync(int id)
        {
            return await _db.Course.Include(c => c.Category).Include(c => c.Tutor).FirstOrDefaultAsync(c => c.Id == id);
        }

        
        public IQueryable<Course> GetAllByTutor(int tutorId)
        {  
            var courses = _db.Course.Include(c => c.Category).Include(c => c.Tutor);
            return courses.Where(c => c.TutorId == tutorId); 
        }

        public IQueryable<Course> GetAll()
        {
            return _db.Course.Include(c => c.Category).Include(c => c.Tutor);
        }
        

        public async Task<bool> UpdateAsync(Course course)
        {
            var objFromDb = await _db.Course.FirstOrDefaultAsync(c => c.Id == course.Id);

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



            await _db.SaveChangesAsync();
            return true;
        }
        
    }
}
