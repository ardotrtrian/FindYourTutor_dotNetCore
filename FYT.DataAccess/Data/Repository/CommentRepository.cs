using FYT.DataAccess.Data.Repository.IRepository;
using FYT.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace FYT.DataAccess.Data.Repository
{
    public class CommentRepository : Repository<Comment>, ICommentRepository
    {
        private readonly ApplicationDbContext _db;

        public CommentRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }
        public IQueryable<Comment> GetAllByStudent(int studentId)
        {
            return _db.Comment.Where(c => c.UserId == studentId);
        }

        public new async Task<Comment> GetAsync(int id)
        {
            return await _db.Comment.Include(c => c.Course).Include(c => c.User).FirstOrDefaultAsync(c => c.Id == id);
        }
        public IQueryable<Comment> GetAll(int courseId)
        {
            var courses = _db.Comment.Include(c => c.Course).Include(c => c.User);
            return _db.Comment.Where(c => c.Course.Id == courseId);
        }

        public async Task<bool> UpdateAsync(Comment comment)
        {
            var objFromDb = await _db.Comment.FirstOrDefaultAsync(c => c.Id == comment.Id);

            if (objFromDb == null)
            {
                return false;
            }
            objFromDb.Description = "(*edited)" + comment.Description;

            await _db.SaveChangesAsync();
            return true;
        }

        public IQueryable<Comment> GetAll()
        {
            return _db.Comment.Include(c => c.Course).Include(c => c.User);
        }

        public new IQueryable<Comment> GetSome(Expression<Func<Comment, bool>> where)
            => _db.Comment.Include(c => c.Course).Include(c => c.User).Where(where);
    }
}
