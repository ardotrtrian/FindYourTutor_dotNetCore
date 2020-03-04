using FYT.BusinessLogic.IBusinessRules;
using FYT.DataAccess.Data.Repository.IRepository;
using FYT.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace FYT.BusinessLogic.BusinessRules
{
    public class CourseBusinessRule : ICourseBusinessRule<Course>
    {
        private readonly IUnitOfWork _unitOfWork;

        public CourseBusinessRule(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IEnumerable<Course> GetAll()
        {
            return _unitOfWork.Course.GetAll() ;
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
    }
}
