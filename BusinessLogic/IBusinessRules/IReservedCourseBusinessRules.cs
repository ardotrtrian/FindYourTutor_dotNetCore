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

        public bool Update(ReservedCourse reservedCourse);
    }
}
