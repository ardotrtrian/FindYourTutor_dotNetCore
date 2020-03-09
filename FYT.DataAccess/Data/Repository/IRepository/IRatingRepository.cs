using FYT.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace FYT.DataAccess.Data.Repository.IRepository
{
    public interface IRatingRepository : IRepository<Rating>
    {
        bool Update(Rating rating);

        IEnumerable<Rating> GetAll(int courseId);
        
        IEnumerable<Rating> GetAllByStudent(int studentId);
        
    }
}
