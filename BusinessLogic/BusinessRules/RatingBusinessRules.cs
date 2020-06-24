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
    public class RatingBusinessRules : IRatingBusinessRules<Rating>
    {
        private readonly IUnitOfWork _unitOfWork;

        public RatingBusinessRules(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Rating> CreateAsync(Rating rating)
        {
            _unitOfWork.Rating.Add(rating);
            await _unitOfWork.SaveAsync();
            return rating;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var objFromDb = await _unitOfWork.Rating.GetAsync(id);

            if (objFromDb == null)
            {
                return false;
            }

            _unitOfWork.Rating.Remove(objFromDb);
            await _unitOfWork.SaveAsync();

            return true;
        }

        public async Task<IEnumerable<Rating>> GetAllAsync()
        {
            return await _unitOfWork.Rating.GetAll().ToListAsync();
        }

        public async Task<IEnumerable<Rating>> GetAllAsync(int courseId)
        {
            return await _unitOfWork.Rating.GetAll(courseId).ToListAsync();
        }

        public async Task<Rating> GetAsync(int id)
        {
            return await _unitOfWork.Rating.GetAsync(id);
        }

        public async Task<bool> UpdateAsync(Rating rating)
        {
            return await _unitOfWork.Rating.UpdateAsync(rating);
        }
    }
}
