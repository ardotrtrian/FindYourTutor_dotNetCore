using FYT.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FYT.BusinessLogic.IBusinessRules
{
    public interface ICourseBusinessRules<T> : IBusinessRules<T> where T : Course
    {
        //public Task<IEnumerable<Course>> GetAllAsync();

        public Task<IEnumerable<Course>> GetAllAsync(int TutorId);

        //public Task<Course> GetAsync(int id);

        //public Task<bool> DeleteAsync(int id);

        //public Task<Course> CreateAsync(Course course);

        //public Task<bool> UpdateAsync(Course course);

        public Task<IEnumerable<User>> GetTutorsAsync();

        public Task<IEnumerable<Comment>> GetCommentsAsync(int id); 

        public Task<IEnumerable<Category>> GetCategoriesAsync();

    }
}
