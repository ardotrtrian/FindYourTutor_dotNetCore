using FYT.DataAccess.Data.Repository.IRepository;
using FYT.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FYT.DataAccess.Data.Repository
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        private readonly ApplicationDbContext _db;

        public UserRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public IEnumerable<User> GetAll(Role role)
        {
            return _db.User.Where(u => u.Role == role);
        }

        public bool Update(User user)
        {
            var objFromDb = _db.User.FirstOrDefault(u => u.Id == user.Id);
            if(objFromDb == null)
            {
                return false;
            }

            objFromDb.UserName = user.UserName;
            objFromDb.Email = user.Email;
            objFromDb.Image = user.Image;
            objFromDb.Password = user.Password;
            
            _db.SaveChanges();
            return true;
        }
    }
}
