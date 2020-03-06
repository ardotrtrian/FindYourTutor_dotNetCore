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
        public IEnumerable<Comment> GetAll(User Student)
        {
            return _db.Comment.Where(c => c.Student.Id == Student.Id);
        }

        public IEnumerable<Comment> GetAll(Course Course)
        {
            return _db.Comment.Where(c => c.Course.Id == Course.Id);
        }

        public void Update(Comment comment)
        {
            var objFromDb = _db.Comment.FirstOrDefault(c => c.Id == comment.Id);

            objFromDb.Description = "(*edited)" + comment.Description;

            _db.SaveChanges();
        }
    }
}
