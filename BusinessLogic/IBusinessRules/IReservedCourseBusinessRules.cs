using FYT.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FYT.BusinessLogic.IBusinessRules
{
    public interface IReservedCourseBusinessRules<T> : IBusinessRules<T> where T : ReservedCourse
    {
        //public Task<IEnumerable<ReservedCourse>> GetAllAsync();

        public Task<IEnumerable<ReservedCourse>> GetAllAsync(int studentId);

        public Task<IEnumerable<ReservedCourse>> GetAllByCourseAsync(int courseId);

        //public Task<ReservedCourse> GetAsync(int id);

        //public Task<bool> DeleteAsync(int id);

        //public Task<ReservedCourse> CreateAsync(ReservedCourse reservedCourse);

        public Task<IEnumerable<User>> GetUsersAsync();

        public Task<Course> GetCourseAsync(int id);

        public Task<IEnumerable<Course>> GetCoursesAsync();

        public Task<IEnumerable<Comment>> GetCommentsAsync(int id);

        //public Task<bool> UpdateAsync(ReservedCourse reservedCourse);
    }
}
