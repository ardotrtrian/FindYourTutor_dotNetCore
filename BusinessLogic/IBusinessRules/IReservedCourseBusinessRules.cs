using FYT.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace FYT.BusinessLogic.IBusinessRules
{
    public interface IReservedCourseBusinessRules<T> where T : ReservedCourse
    {
        public IEnumerable<ReservedCourse> GetAll();

        public IEnumerable<ReservedCourse> GetAll(int studentId);

        public IEnumerable<ReservedCourse> GetAllByCourse(int courseId);

        public ReservedCourse GetById(int id);

        public bool Delete(int id);

        public ReservedCourse Create(ReservedCourse reservedCourse);

        public IEnumerable<User> GetUsers();

        public Course GetCourse(int id);

        public IEnumerable<Course> GetCourses();

        public IEnumerable<Comment> GetComments(int id);

        public bool Update(ReservedCourse reservedCourse);
    }
}
