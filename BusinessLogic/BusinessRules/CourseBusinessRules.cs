using FYT.BusinessLogic.IBusinessRules;
using FYT.DataAccess.Data.Repository.IRepository;
using FYT.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace FYT.BusinessLogic.BusinessRules
{
    public class CourseBusinessRules : ICourseBusinessRules<Course>
    {
        private readonly IUnitOfWork _unitOfWork;

        public CourseBusinessRules(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IEnumerable<Course> GetAll()
        {
            return _unitOfWork.Course.GetAll();
        }

        public bool Delete(int id)
        {
            var objFromDb = _unitOfWork.Course.Get(id);

            if (objFromDb == null)
            {
                return false;
            }

            _unitOfWork.Course.Remove(objFromDb);
            _unitOfWork.Save();

            return true;
        }

        public IEnumerable<Course> GetAll(int TutorId)
        {
            return _unitOfWork.Course.GetAll(TutorId);
        }

        public Course Create(Course course)
        {
            _unitOfWork.Course.Add(course);
            _unitOfWork.Save();
            return course;
        }

        public bool Update(Course course)
        {
            return _unitOfWork.Course.Update(course);

        }

        public Course GetById(int id)
        {
            return _unitOfWork.Course.Get(id);
        }

        public IEnumerable<User> GetTutors()
        {
            return _unitOfWork.User.GetSome(t => t.Role == Role.Tutor);
        }

        public IEnumerable<Comment> GetComments(int id)
        {
            return _unitOfWork.Comment.GetSome(c => c.CourseId == id);
        }

        public IEnumerable<Category> GetCategories()
        {
            return _unitOfWork.Category.GetAll();
        }

    }
}
