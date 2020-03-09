using FYT.BusinessLogic.IBusinessRules;
using FYT.DataAccess.Data.Repository.IRepository;
using FYT.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace FYT.BusinessLogic.BusinessRules
{
    public class CategoryBusinessRules : ICategoryBusinessRules<Category>
    {
        private readonly IUnitOfWork _unitOfWork;

        public CategoryBusinessRules(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void Create(Category category)
        {
            _unitOfWork.Category.Add(category);
            _unitOfWork.Save();
        }

        public bool Delete(int id)
        {
            var objFromDb = _unitOfWork.Category.Get(id);

            if (objFromDb == null)
            {
                return false;
            }

            _unitOfWork.Category.Remove(objFromDb);
            _unitOfWork.Save();

            return true;
        }

        public IEnumerable<Category> GetAll()
        {
            return _unitOfWork.Category.GetAll();
        }

        public Category GetById(int id)
        {
            return _unitOfWork.Category.Get(id);
        }

        public void Update(Category category)
        {
            _unitOfWork.Category.Update(category);
        }
    }
}
