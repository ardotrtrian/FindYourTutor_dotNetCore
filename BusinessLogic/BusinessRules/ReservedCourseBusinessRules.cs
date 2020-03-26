using FYT.BusinessLogic.IBusinessRules;
using FYT.DataAccess.Data.Repository.IRepository;
using FYT.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace FYT.BusinessLogic.BusinessRules
{
    public class ReservedCourseBusinessRules : IReservedCourseBusinessRules<ReservedCourse>
    {
        private readonly IUnitOfWork _unitOfWork;

        public ReservedCourseBusinessRules(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public ReservedCourse Create(ReservedCourse reservedCourse)
        {
            _unitOfWork.ReservedCourse.Add(reservedCourse);
            _unitOfWork.Save();
            return reservedCourse;
        }

        public bool Delete(int id)
        {
            var objFromDb = _unitOfWork.ReservedCourse.Get(id);

            if (objFromDb == null)
            {
                return false;
            }

            _unitOfWork.ReservedCourse.Remove(objFromDb);
            _unitOfWork.Save();

            return true;
        }

        public IEnumerable<ReservedCourse> GetAll()
        {
            return _unitOfWork.ReservedCourse.GetAll();
        }

        public IEnumerable<ReservedCourse> GetAll(int studentId)
        {
            return _unitOfWork.ReservedCourse.GetAll(studentId);
        }

        public IEnumerable<ReservedCourse> GetAllByCourse(int courseId)
        {
            return _unitOfWork.ReservedCourse.GetAllByCourse(courseId);
        }

        public ReservedCourse GetById(int id)
        {
            return _unitOfWork.ReservedCourse.Get(id);
        }

        public IEnumerable<Comment> GetComments(int id)
        {
            return _unitOfWork.Comment.GetSome(c => c.CourseId == id);
        }

        public Course GetCourse(int id)
        {
            return _unitOfWork.Course.Get(id);
        }

        public IEnumerable<Course> GetCourses()
        {
            return _unitOfWork.Course.GetAll();
        }

        public IEnumerable<User> GetUsers()
        {
            return _unitOfWork.User.GetAll();
        }

        public bool Update(ReservedCourse reservedCourse)
        {
            return _unitOfWork.ReservedCourse.Update(reservedCourse);
        }
    }
}
