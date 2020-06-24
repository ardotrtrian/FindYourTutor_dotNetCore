using FYT.BusinessLogic.IBusinessRules;
using FYT.DataAccess.Data.Repository.IRepository;
using FYT.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace FYT.BusinessLogic.BusinessRules
{
    public class UserBusinessRules : IUserBusinessRules<User>
    {
        private readonly IUnitOfWork _unitOfWork;

        public UserBusinessRules(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<User> CreateAsync(User user)
        {
            _unitOfWork.User.Add(user);
            await _unitOfWork.SaveAsync();
            return user;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var objFromDb = await _unitOfWork.User.GetAsync(id);

            if (objFromDb == null)
            {
                return false;
            }

            _unitOfWork.User.Remove(objFromDb);
            await _unitOfWork.SaveAsync();

            return true;
        }

        public async Task<IEnumerable<User>> GetAllAsync()
        {
            return await _unitOfWork.User.GetAll().ToListAsync();
        }

        public async Task<IEnumerable<User>> GetAllByRoleAsync(Role role)
        {
            return await _unitOfWork.User.GetAllByRole(role).ToListAsync();
        }

        public async Task<User> GetByIdAsync(int id)
        {
            return await _unitOfWork.User.GetAsync(id);
        }

        public async Task<bool> UpdateAsync(User user)
        {
            return await _unitOfWork.User.UpdateAsync(user);
        }
    }
}
