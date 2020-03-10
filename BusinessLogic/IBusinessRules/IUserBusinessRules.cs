using FYT.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace FYT.BusinessLogic.IBusinessRules
{
    public interface IUserBusinessRules<T> where T : User
    {
        public IEnumerable<User> GetAll();

        public IEnumerable<User> GetAll(Role role); 

        public User GetById(int id);

        public bool Delete(int id);

        public User Create(User user);

        public bool Update(User user); 
    }
}
