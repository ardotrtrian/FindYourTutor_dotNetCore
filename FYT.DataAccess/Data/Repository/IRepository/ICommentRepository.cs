using FYT.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace FYT.DataAccess.Data.Repository.IRepository
{
    public interface ICommentRepository : IRepository<Comment>
    {
        bool Update(Comment comment);

        IEnumerable<Comment> GetAllByStudent(int studentId);
        
        IEnumerable<Comment> GetAll(int courseId);
    }
}
