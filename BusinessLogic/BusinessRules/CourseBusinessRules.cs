using FYT.BusinessLogic.IBusinessRules;
using FYT.DataAccess.Data.Repository.IRepository;
using FYT.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FYT.BusinessLogic.BusinessRules
{
    public class CourseBusinessRules : ICourseBusinessRules<Course>
    {
        private readonly IUnitOfWork _unitOfWork;

        public CourseBusinessRules(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<Course>> GetAllAsync()
        {
            return await _unitOfWork.Course.GetAll().ToListAsync();
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var objFromDb = await _unitOfWork.Course.GetAsync(id);

            if (objFromDb == null)
            {
                return false;
            }

            _unitOfWork.Course.Remove(objFromDb);
            await _unitOfWork.SaveAsync();

            return true;
        }

        public async Task<IEnumerable<Course>> GetAllAsync(int TutorId)
        {
            return await _unitOfWork.Course.GetAllByTutor(TutorId).ToListAsync();
        }

        public async Task<Course> CreateAsync(Course course)
        {
            _unitOfWork.Course.Add(course);
            await _unitOfWork.SaveAsync();
            return course;
        }

        public async Task<bool> UpdateAsync(Course course)
        {
            return await _unitOfWork.Course.UpdateAsync(course);

        }

        public async Task<Course> GetAsync(int id)
        {
            return await _unitOfWork.Course.GetAsync(id);
        }

        public async Task<IEnumerable<User>> GetTutorsAsync()
        {
            return await _unitOfWork.User.GetSome(t => t.Role == Role.Tutor).ToListAsync();
        }

        public async Task<IEnumerable<Comment>> GetCommentsAsync(int id)
        {
            return await _unitOfWork.Comment.GetSome(c => c.CourseId == id).ToListAsync();
        }

        public async Task<IEnumerable<Category>> GetCategoriesAsync()
        {
            return await _unitOfWork.Category.GetAll().ToListAsync();
        }

    }
}
