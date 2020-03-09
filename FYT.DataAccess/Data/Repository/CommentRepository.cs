using FYT.DataAccess.Data.Repository.IRepository;
using FYT.Models;
using System;
using System.Collections.Generic;
using System.Linq;
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

        public IEnumerable<Comment> GetAll(int courseId)
        {
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
    }
}
