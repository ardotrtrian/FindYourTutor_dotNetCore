using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace FYT.DataAccess.Data.Repository.IRepository
{
    public interface IRepository<T> where T : class
    {
        T Get(int id);

        IEnumerable<T> GetAll(
            Expression<Func<T,bool>> filter = null,
            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
            string includeProperties = null
            );

        T GetFirstOrDefault(
            Expression<Func<T,bool>> filter = null,
            string includeProperties = null
            );
        public IEnumerable<T> GetSome(Expression<Func<T, bool>> where);

        void Add(T entity);

        void Remove(int id);

        void Remove(T entity);
    }
}
