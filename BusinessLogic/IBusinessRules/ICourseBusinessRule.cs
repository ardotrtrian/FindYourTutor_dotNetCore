using FYT.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace FYT.BusinessLogic.IBusinessRules
{
    public interface ICourseBusinessRule<T> where T : Course
    {
        public IEnumerable<Course> GetAll();

        public bool Delete(int id);

    }
}
