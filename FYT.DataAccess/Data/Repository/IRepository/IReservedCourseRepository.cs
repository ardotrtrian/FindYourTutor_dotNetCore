using FYT.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FYT.DataAccess.Data.Repository.IRepository
{
    public interface IReservedCourseRepository : IRepository<ReservedCourse>
    {
        Task<bool> UpdateAsync(ReservedCourse reservedCourse);

        IQueryable<ReservedCourse> GetAll(int studentId);

        IQueryable<ReservedCourse> GetAllByCourse(int courseId);

        IQueryable<ReservedCourse> GetAllByStatus(Status status);
    }
}
