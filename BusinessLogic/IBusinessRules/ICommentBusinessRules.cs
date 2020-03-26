using FYT.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace FYT.BusinessLogic.IBusinessRules
{
    public interface ICommentBusinessRules<T> where T : Comment
    {
        public IEnumerable<Comment> GetAll();

        public IEnumerable<Comment> GetAll(int courseId);

        public Comment GetById(int id);

        public bool Delete(int id);

        public Comment Create(Comment comment);

        public bool Update(Comment comment);

        public IEnumerable<Course> GetCourses();

        public IEnumerable<User> GetUsers();
    }
}
