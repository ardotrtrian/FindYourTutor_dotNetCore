using FYT.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace FYT.DataAccess.Data.Repository.IRepository
{
    interface ICourseRepository : IRepository<Course>
    {
        void Update(Course course);

    }
}
