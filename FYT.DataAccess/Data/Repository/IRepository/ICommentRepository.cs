using FYT.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace FYT.DataAccess.Data.Repository.IRepository
{
    public interface ICommentRepository : IRepository<Comment>
    {
        Task<bool> UpdateAsync(Comment comment);

        IQueryable<Comment> GetAll();

        IQueryable<Comment> GetAllByStudent(int studentId);

        new IQueryable<Comment> GetSome(Expression<Func<Comment, bool>> where);

        IQueryable<Comment> GetAll(int courseId);
    }
}
