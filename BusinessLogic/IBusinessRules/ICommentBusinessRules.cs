using FYT.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FYT.BusinessLogic.IBusinessRules
{
    public interface ICommentBusinessRules<T> : IBusinessRules<T> where T : Comment
    {
        //public Task<IEnumerable<Comment>> GetAllAsync();

        public Task<IEnumerable<Comment>> GetAllAsync(int courseId);

        //public Task<Comment> GetAsync(int id);

        //public Task<bool> DeleteAsync(int id);

        //public Task<Comment> CreateAsync(Comment comment);

        //public Task<bool> UpdateAsync(Comment comment);

        public Task<IEnumerable<Course>> GetCoursesAsync();

        public Task<IEnumerable<User>> GetUsersAsync();
    }
}
