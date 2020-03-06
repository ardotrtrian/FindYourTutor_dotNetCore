using FYT.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace FYT.DataAccess.Data.Repository.IRepository
{
    public interface IReservedCourseRepository : IRepository<ReservedCourse>
    {
        void Update(ReservedCourse reservedCourse);

        IEnumerable<ReservedCourse> GetAll(User Student);

        IEnumerable<ReservedCourse> GetAll(Course course);

        IEnumerable<ReservedCourse> GetAll(Status status);
    }
}
