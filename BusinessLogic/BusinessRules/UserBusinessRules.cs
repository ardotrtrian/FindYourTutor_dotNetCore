using FYT.BusinessLogic.IBusinessRules;
using FYT.DataAccess.Data.Repository.IRepository;
using FYT.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace FYT.BusinessLogic.BusinessRules
{
    public class UserBusinessRules : IUserBusinessRules<User>
    {
        private readonly IUnitOfWork _unitOfWork;

        public UserBusinessRules(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public User Create(User user)
        {
            _unitOfWork.User.Add(user);
            _unitOfWork.Save();
            return user;
        }

        public bool Delete(int id)
        {
            var objFromDb = _unitOfWork.User.Get(id);

            if (objFromDb == null)
            {
                return false;
            }

            _unitOfWork.User.Remove(objFromDb);
            _unitOfWork.Save();

            return true;
        }

        public IEnumerable<User> GetAll()
        {
            return _unitOfWork.User.GetAll();
        }

        public IEnumerable<User> GetAll(Role role)
        {
            return _unitOfWork.User.GetAll(role);
        }

        public User GetById(int id)
        {
            return _unitOfWork.User.Get(id);
        }

        public bool Update(User user)
        {
            return _unitOfWork.User.Update(user);
        }
    }
}
