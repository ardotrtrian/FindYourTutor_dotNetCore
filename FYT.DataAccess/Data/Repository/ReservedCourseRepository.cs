using FYT.DataAccess.Data.Repository.IRepository;
using FYT.Models;
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

        public IEnumerable<ReservedCourse> GetAll(int studentId)
        {
            return _db.ReservedCourse.Where(r => r.StudentId == studentId);
        }

        public IEnumerable<ReservedCourse> GetAllByCourse(int courseId)
        {
            return _db.ReservedCourse.Where(r => r.Course.Id == courseId);
        }

        public IEnumerable<ReservedCourse> GetAll(Status status)
        {
            return _db.ReservedCourse.Where(r => r.Status == status);
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
