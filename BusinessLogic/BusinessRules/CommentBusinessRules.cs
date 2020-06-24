using FYT.BusinessLogic.IBusinessRules;
using FYT.DataAccess.Data.Repository.IRepository;
using FYT.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FYT.BusinessLogic.BusinessRules
{
    public class CommentBusinessRules : ICommentBusinessRules<Comment>
    {

        private readonly IUnitOfWork _unitOfWork;

        public CommentBusinessRules(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<Comment> CreateAsync(Comment comment)
        {
            _unitOfWork.Comment.Add(comment);
            await _unitOfWork.SaveAsync();
            return comment;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var objFromDb = await _unitOfWork.Comment.GetAsync(id);

            if (objFromDb == null)
            {
                return false;
            }

            _unitOfWork.Comment.Remove(objFromDb);
            await _unitOfWork.SaveAsync();

            return true;
        }

        public async Task<IEnumerable<Comment>> GetAllAsync()
        {
            return await _unitOfWork.Comment.GetAll().ToListAsync();
        }

        public async Task<IEnumerable<Comment>> GetAllAsync(int courseId)
        {
            return await _unitOfWork.Comment.GetAll(courseId).ToListAsync();
        }

        public async Task<Comment> GetAsync(int id)
        {
            return await _unitOfWork.Comment.GetAsync(id);
        }

        public async Task<IEnumerable<Course>> GetCoursesAsync()
        {
            return await _unitOfWork.Course.GetAll().ToListAsync();
        }

        public async Task<IEnumerable<User>> GetUsersAsync()
        {
            return await _unitOfWork.User.GetAll().ToListAsync();
        }

        public async Task<bool> UpdateAsync(Comment comment)
        {
            return await _unitOfWork.Comment.UpdateAsync(comment);
        }
    }
}
