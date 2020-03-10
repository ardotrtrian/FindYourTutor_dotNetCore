using FYT.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace FYT.BusinessLogic.IBusinessRules
{
    public interface IRatingBusinessRules<T> where T : Rating
    {
        public IEnumerable<Rating> GetAll();

        public IEnumerable<Rating> GetAll(int courseId);

        public Rating GetById(int id);

        public bool Delete(int id);

        public Rating Create(Rating rating);

        public bool Update(Rating rating);
    }
}
