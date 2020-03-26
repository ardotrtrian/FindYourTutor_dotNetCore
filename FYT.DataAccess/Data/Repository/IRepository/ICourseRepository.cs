using FYT.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace FYT.DataAccess.Data.Repository.IRepository
{
    public interface ICourseRepository : IRepository<Course>
    {
        bool Update(Course course);

        IEnumerable<Course> GetAll();

        IEnumerable<Course> GetAll(int TutorId);

        //Comment AddComment(Comment comment);
    }
}
