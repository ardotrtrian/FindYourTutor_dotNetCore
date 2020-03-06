using System;
using System.Collections.Generic;
using System.Text;

namespace FYT.DataAccess.Data.Repository.IRepository
{
    public interface IUnitOfWork : IDisposable
    {
        ICategoryRepository Category { get; }

        ICourseRepository Course { get; }

        IImageRepository Image { get; }
        
        ICommentRepository Comment { get; }

        IRatingRepository Rating { get; }

        IReservedCourseRepository ReservedCourse { get; }

        IUserRepository UserRepository { get; }

        void Save();
    }
}
