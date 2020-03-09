using FYT.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace FYT.DataAccess.Data.Repository.IRepository
{
    public interface IUserRepository : IRepository<User>
    {
        bool Update(User user);

        IEnumerable<User> GetAll(Role role);
    }
}
