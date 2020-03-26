using FYT.BusinessLogic.IBusinessRules;
using FYT.DataAccess.Data.Repository.IRepository;
using FYT.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace FYT.BusinessLogic.BusinessRules
{
    public class CommentBusinessRules : ICommentBusinessRules<Comment>
    {

        private readonly IUnitOfWork _unitOfWork;

        public CommentBusinessRules(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public Comment Create(Comment comment)
        {
            _unitOfWork.Comment.Add(comment);
            _unitOfWork.Save();
            return comment;
        }

        public bool Delete(int id)
        {
            var objFromDb = _unitOfWork.Comment.Get(id);

            if (objFromDb == null)
            {
                return false;
            }

            _unitOfWork.Comment.Remove(objFromDb);
            _unitOfWork.Save();

            return true;
        }

        public IEnumerable<Comment> GetAll()
        {
            return _unitOfWork.Comment.GetAll();
        }

        public IEnumerable<Comment> GetAll(int courseId)
        {
            return _unitOfWork.Comment.GetAll(courseId);
        }

        public Comment GetById(int id)
        {
            return _unitOfWork.Comment.Get(id);
        }

        public IEnumerable<Course> GetCourses()
        {
            return _unitOfWork.Course.GetAll();
        }

        public IEnumerable<User> GetUsers()
        {
            return _unitOfWork.User.GetAll();
        }

        public bool Update(Comment comment)
        {
            return _unitOfWork.Comment.Update(comment);
        }
    }
}
