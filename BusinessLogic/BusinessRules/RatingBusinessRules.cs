using FYT.BusinessLogic.IBusinessRules;
using FYT.DataAccess.Data.Repository.IRepository;
using FYT.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace FYT.BusinessLogic.BusinessRules
{
    public class RatingBusinessRules : IRatingBusinessRules<Rating>
    {
        private readonly IUnitOfWork _unitOfWork;

        public RatingBusinessRules(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public Rating Create(Rating rating)
        {
            _unitOfWork.Rating.Add(rating);
            _unitOfWork.Save();
            return rating;
        }

        public bool Delete(int id)
        {
            var objFromDb = _unitOfWork.Rating.Get(id);

            if (objFromDb == null)
            {
                return false;
            }

            _unitOfWork.Rating.Remove(objFromDb);
            _unitOfWork.Save();

            return true;
        }

        public IEnumerable<Rating> GetAll()
        {
            return _unitOfWork.Rating.GetAll();
        }

        public IEnumerable<Rating> GetAll(int courseId)
        {
            return _unitOfWork.Rating.GetAll(courseId);
        }

        public Rating GetById(int id)
        {
            return _unitOfWork.Rating.Get(id);
        }

        public bool Update(Rating rating)
        {
            return _unitOfWork.Rating.Update(rating);
        }
    }
}
