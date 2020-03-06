using FYT.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace FYT.DataAccess.Data.Repository.IRepository
{
    public interface IRatingRepository : IRepository<Rating>
    {
        void Update(Rating rating);

        IEnumerable<Rating> GetAll(Course course);

        public IEnumerable<Rating> GetAll(User Student);
        
    }
}
