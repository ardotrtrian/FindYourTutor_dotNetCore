using FYT.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FYT.DataAccess.Data.Repository.IRepository
{
    public interface ICourseRepository : IRepository<Course>
    {
        Task<bool> UpdateAsync(Course course);

        IQueryable<Course> GetAll();

        IQueryable<Course> GetAllByTutor(int TutorId);

    }
}
