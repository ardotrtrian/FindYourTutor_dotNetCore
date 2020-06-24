using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace FYT.DataAccess.Data.Repository.IRepository
{
    public interface IRepository<T> where T : class
    {
        Task<T> GetAsync(int id);

        IQueryable<T> GetAll(
            Expression<Func<T,bool>> filter = null,
            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
            string includeProperties = null
            );

        Task<T> GetFirstOrDefaultAsync(
            Expression<Func<T,bool>> filter = null,
            string includeProperties = null
            );
        public IQueryable<T> GetSome(Expression<Func<T, bool>> where);

        void Add(T entity);

        Task Remove(int id);

        void Remove(T entity);
    }
}
