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
    public class ReservedCourseRepository : Repository<ReservedCourse>, IReservedCourseRepository
    {
        private readonly ApplicationDbContext _db;

        public ReservedCourseRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public new async Task<ReservedCourse> GetAsync(int id)
        {
            return await _db.ReservedCourse.Include(r => r.Course).Include(r => r.Student).FirstOrDefaultAsync(r => r.Id == id);
        }

        public IQueryable<ReservedCourse> GetAll(int studentId)
        {
            var rCourses = _db.ReservedCourse.Include(r => r.Course).Include(r => r.Student);
            return rCourses.Where(c => c.StudentId == studentId);
        }

        public IQueryable<ReservedCourse> GetAllByCourse(int courseId)
        {
            var rCourses = _db.ReservedCourse.Include(r => r.Course).Include(r => r.Student);
            return rCourses.Where(r => r.Course.Id == courseId);
        }

        public IQueryable<ReservedCourse> GetAllByStatus(Status status)
        {
            var rCourses = _db.ReservedCourse.Include(r => r.Course).Include(r => r.Student);
            return rCourses.Where(r => r.Status == status);
        }

        public async Task<bool> UpdateAsync(ReservedCourse reservedCourse)
        {
            var objFromDb = await _db.ReservedCourse.FirstOrDefaultAsync(r => r.Id == reservedCourse.Id);
            if(objFromDb == null)
            {
                return false;
            }
            objFromDb.Status = reservedCourse.Status;
            
            await _db.SaveChangesAsync();
            return true;
        }
    }
}
