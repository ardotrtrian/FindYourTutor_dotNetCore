using FYT.DataAccess.Data.Repository.IRepository;
using FYT.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FYT.DataAccess.Data.Repository
{
    public class ReservedCourseRepository : Repository<ReservedCourse>, IReservedCourseRepository
    {
        private readonly ApplicationDbContext _db;

        public ReservedCourseRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public new ReservedCourse Get(int id)
        {
            return _db.ReservedCourse.Include(r => r.Course).Include(r => r.Student).FirstOrDefault(r => r.Id == id);
        }

        public IEnumerable<ReservedCourse> GetAll(int studentId)
        {
            var rCourses = _db.ReservedCourse.Include(r => r.Course).Include(r => r.Student);
            return rCourses.Where(c => c.StudentId == studentId);
        }

        public IEnumerable<ReservedCourse> GetAllByCourse(int courseId)
        {
            var rCourses = _db.ReservedCourse.Include(r => r.Course).Include(r => r.Student);
            return rCourses.Where(r => r.Course.Id == courseId);
        }

        public IEnumerable<ReservedCourse> GetAll(Status status)
        {
            var rCourses = _db.ReservedCourse.Include(r => r.Course).Include(r => r.Student);
            return rCourses.Where(r => r.Status == status);
        }

        public bool Update(ReservedCourse reservedCourse)
        {
            var objFromDb = _db.ReservedCourse.FirstOrDefault(r => r.Id == reservedCourse.Id);
            if(objFromDb == null)
            {
                return false;
            }
            objFromDb.Status = reservedCourse.Status;
            
            _db.SaveChanges();
            return true;
        }
    }
}
