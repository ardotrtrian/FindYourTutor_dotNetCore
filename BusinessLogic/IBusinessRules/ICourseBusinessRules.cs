using FYT.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace FYT.BusinessLogic.IBusinessRules
{
    public interface ICourseBusinessRules<T> where T : Course
    {
        public IEnumerable<Course> GetAll();
        
        public IEnumerable<Course> GetAll(int TutorId);

        public Course GetById(int id);
        
        public bool Delete(int id);

        public void Create(Course course);

        public bool Update(Course course);


    }
}
