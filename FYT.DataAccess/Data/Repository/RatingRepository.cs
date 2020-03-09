using FYT.DataAccess.Data.Repository.IRepository;
using FYT.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FYT.DataAccess.Data.Repository
{
    public class RatingRepository : Repository<Rating>, IRatingRepository
    {
        private readonly ApplicationDbContext _db;

        public RatingRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public IEnumerable<Rating> GetAll(int courseId)
        {
            return _db.Rating.Where(r => r.Course.Id == courseId);
        }

        public IEnumerable<Rating> GetAllByStudent(int studentId)
        {
            return _db.Rating.Where(r => r.StudentId == studentId);
        }

        public bool Update(Rating rating)
        {
            var objFromDb = _db.Rating.FirstOrDefault(r => r.Id == rating.Id);
            if(objFromDb == null)
            {
                return false;
            }
            objFromDb.Rate = rating.Rate;            

            _db.SaveChanges();
            return true;
        }
    }
}
