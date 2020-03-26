using FYT.DataAccess.Data.Repository.IRepository;
using FYT.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace FYT.DataAccess.Data.Repository
{
    public class CommentRepository : Repository<Comment>, ICommentRepository
    {
        private readonly ApplicationDbContext _db;

        public CommentRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }
        public IEnumerable<Comment> GetAllByStudent(int studentId)
        {
            return _db.Comment.Where(c => c.UserId == studentId);
        }

        public new Comment Get(int id)
        {
            return _db.Comment.Include(c => c.Course).Include(c => c.User).FirstOrDefault(c => c.Id == id);
        }
        public IEnumerable<Comment> GetAll(int courseId)
        {
            var courses = _db.Comment.Include(c => c.Course).Include(c => c.User);
            return _db.Comment.Where(c => c.Course.Id == courseId);
        }

        public bool Update(Comment comment)
        {
            var objFromDb = _db.Comment.FirstOrDefault(c => c.Id == comment.Id);

            if (objFromDb == null)
            {
                return false;
            }
            objFromDb.Description = "(*edited)" + comment.Description;

            _db.SaveChanges();
            return true;
        }

        public IEnumerable<Comment> GetAll()
        {
            return _db.Comment.Include(c => c.Course).Include(c => c.User);
        }

        public new IEnumerable<Comment> GetSome(Expression<Func<Comment, bool>> where)
            => _db.Comment.Include(c => c.Course).Include(c => c.User).Where(where);
    }
}
