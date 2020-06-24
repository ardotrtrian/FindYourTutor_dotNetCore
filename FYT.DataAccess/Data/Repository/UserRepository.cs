using FYT.DataAccess.Data.Repository.IRepository;
using FYT.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FYT.DataAccess.Data.Repository
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        private readonly ApplicationDbContext _db;

        public UserRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public IQueryable<User> GetAllByRole(Role role)
        {
            return _db.User.Where(u => u.Role == role);
        }

        public async Task<bool> UpdateAsync(User user)
        {
            var objFromDb = await _db.User.FirstOrDefaultAsync(u => u.Id == user.Id);
            if(objFromDb == null)
            {
                return false;
            }

            objFromDb.UserName = user.UserName;
            objFromDb.Email = user.Email;
            //objFromDb.Image = user.Image;
            objFromDb.Password = user.Password;
            
            await _db.SaveChangesAsync();
            return true;
        }
    }
}
