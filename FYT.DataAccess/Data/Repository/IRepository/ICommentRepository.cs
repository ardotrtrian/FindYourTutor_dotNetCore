using FYT.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace FYT.DataAccess.Data.Repository.IRepository
{
    public interface ICommentRepository : IRepository<Comment>
    {
        void Update(Comment comment);

        IEnumerable<Comment> GetAll(User Student);

        IEnumerable<Comment> GetAll(Course course);
    }
}
