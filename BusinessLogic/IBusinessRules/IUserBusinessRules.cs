using FYT.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FYT.BusinessLogic.IBusinessRules
{
    public interface IUserBusinessRules<T> where T : User
    {
        public Task<IEnumerable<User>> GetAllAsync();

        public Task<IEnumerable<User>> GetAllByRoleAsync(Role role); 

        public Task<User> GetByIdAsync(int id);

        public Task<bool> DeleteAsync(int id);

        public Task<User> CreateAsync(User user);

        public Task<bool> UpdateAsync(User user); 
    }
}
