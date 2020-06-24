using FYT.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FYT.DataAccess.Data.Repository.IRepository
{
    public interface IRatingRepository : IRepository<Rating>
    {
        Task<bool> UpdateAsync(Rating rating);

        IQueryable<Rating> GetAll(int courseId);

        IQueryable<Rating> GetAllByStudent(int studentId);
        
    }
}
