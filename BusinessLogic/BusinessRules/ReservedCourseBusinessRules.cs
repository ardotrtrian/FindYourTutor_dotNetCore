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
    public class ReservedCourseBusinessRules : IReservedCourseBusinessRules<ReservedCourse>
    {
        private readonly IUnitOfWork _unitOfWork;

        public ReservedCourseBusinessRules(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<ReservedCourse> CreateAsync(ReservedCourse reservedCourse)
        {
            _unitOfWork.ReservedCourse.Add(reservedCourse);
            await _unitOfWork.SaveAsync();
            return reservedCourse;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var objFromDb = await _unitOfWork.ReservedCourse.GetAsync(id);

            if (objFromDb == null)
            {
                return false;
            }

            _unitOfWork.ReservedCourse.Remove(objFromDb);
            await _unitOfWork.SaveAsync();

            return true;
        }

        public async Task<IEnumerable<ReservedCourse>> GetAllAsync()
        {
            return await _unitOfWork.ReservedCourse.GetAll().ToListAsync();
        }

        public async Task<IEnumerable<ReservedCourse>> GetAllAsync(int studentId)
        {
            return await _unitOfWork.ReservedCourse.GetAll(studentId).ToListAsync();
        }

        public async Task<IEnumerable<ReservedCourse>> GetAllByCourseAsync(int courseId)
        {
            return await _unitOfWork.ReservedCourse.GetAllByCourse(courseId).ToListAsync();
        }

        public async Task<ReservedCourse> GetAsync(int id)
        {
            return await _unitOfWork.ReservedCourse.GetAsync(id);
        }

        public async Task<IEnumerable<Comment>> GetCommentsAsync(int id)
        {
            return await _unitOfWork.Comment.GetSome(c => c.CourseId == id).ToListAsync();
        }

        public async Task<Course> GetCourseAsync(int id)
        {
            return await _unitOfWork.Course.GetAsync(id);
        }

        public async Task<IEnumerable<Course>> GetCoursesAsync()
        {
            return await _unitOfWork.Course.GetAll().ToListAsync();
        }

        public async Task<IEnumerable<User>> GetUsersAsync()
        {
            return await  _unitOfWork.User.GetAll().ToListAsync();
        }

        public async Task<bool> UpdateAsync(ReservedCourse reservedCourse)
        {
            return await _unitOfWork.ReservedCourse.UpdateAsync(reservedCourse);
        }
    }
}
