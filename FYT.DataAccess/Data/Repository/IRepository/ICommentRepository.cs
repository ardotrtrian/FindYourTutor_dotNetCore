using FYT.Models;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace FYT.DataAccess.Data.Repository.IRepository
{
    public interface ICommentRepository : IRepository<Comment>
    {
        bool Update(Comment comment);

        IEnumerable<Comment> GetAll();

        IEnumerable<Comment> GetAllByStudent(int studentId);

        new IEnumerable<Comment> GetSome(Expression<Func<Comment, bool>> where);

        IEnumerable<Comment> GetAll(int courseId);
    }
}
