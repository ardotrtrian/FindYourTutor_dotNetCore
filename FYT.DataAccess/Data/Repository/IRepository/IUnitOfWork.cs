using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FYT.DataAccess.Data.Repository.IRepository
{
    public interface IUnitOfWork : IDisposable
    {
        ICategoryRepository Category { get; }

        ICourseRepository Course { get; }
        
        ICommentRepository Comment { get; }

        IRatingRepository Rating { get; }

        IReservedCourseRepository ReservedCourse { get; }

        IUserRepository User { get; } 

        Task SaveAsync();
    }
}
