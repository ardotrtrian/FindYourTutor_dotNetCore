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

        public IEnumerable<Rating> GetAll(Course course)
        {
            return _db.Rating.Where(r => r.Course.Id == course.Id);
        }

        public IEnumerable<Rating> GetAll(User Student)
        {
            return _db.Rating.Where(r => r.Student.Id == Student.Id);
        }

        public void Update(Rating rating)
        {
            var objFromDb = _db.Rating.FirstOrDefault(r => r.Id == rating.Id);

            objFromDb.Rate = rating.Rate;            

            _db.SaveChanges();
        }
    }
}
