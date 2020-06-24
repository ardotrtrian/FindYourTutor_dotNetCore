using FYT.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FYT.DataAccess.Data.Repository.IRepository
{
    public interface IUserRepository : IRepository<User>
    {
        Task<bool> UpdateAsync(User user);

        IQueryable<User> GetAllByRole(Role role);
    }
}
