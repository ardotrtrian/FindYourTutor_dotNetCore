using FYT.BusinessLogic.IBusinessRules;
using FYT.DataAccess.Data.Repository.IRepository;
using FYT.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;

namespace FYT.BusinessLogic.BusinessRules
{
    public class CategoryBusinessRules : ICategoryBusinessRules<Category>
    {
        private readonly IUnitOfWork _unitOfWork;

        public CategoryBusinessRules(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Category> CreateAsync(Category category)
        {
            _unitOfWork.Category.Add(category);
            await _unitOfWork.SaveAsync();
            return category;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var objFromDb = await _unitOfWork.Category.GetAsync(id);

            if (objFromDb == null)
            {
                return false;
            }

            _unitOfWork.Category.Remove(objFromDb);
            await _unitOfWork.SaveAsync();

            return true;
        }

        public async Task<IEnumerable<Category>> GetAllAsync()
        {
            return await _unitOfWork.Category.GetAll().ToListAsync();
        }

        public async Task<Category> GetAsync(int id)
        {
            return await _unitOfWork.Category.GetAsync(id);
        }

        public async Task<bool> UpdateAsync(Category category)
        {
            return await _unitOfWork.Category.UpdateAsync(category);
        }
    }
}
