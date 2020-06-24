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
    public class RatingRepository : Repository<Rating>, IRatingRepository
    {
        private readonly ApplicationDbContext _db;

        public RatingRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public IQueryable<Rating> GetAll(int courseId)
        {
            return _db.Rating.Where(r => r.Course.Id == courseId);
        }

        public IQueryable<Rating> GetAllByStudent(int studentId)
        {
            return _db.Rating.Where(r => r.StudentId == studentId);
        }

        public async Task<bool> UpdateAsync(Rating rating)
        {
            var objFromDb = await _db.Rating.FirstOrDefaultAsync(r => r.Id == rating.Id);
            if(objFromDb == null)
            {
                return false;
            }
            objFromDb.Rate = rating.Rate;            

            await _db.SaveChangesAsync();
            return true;
        }
    }
}
