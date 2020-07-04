using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FYT.BusinessLogic.IBusinessRules
{
    public interface IBusinessRules<T> where T : class
    {
        public Task<IEnumerable<T>> GetAllAsync();

        public Task<T> GetAsync(int id);

        public Task<bool> DeleteAsync(int id);

        public Task<T> CreateAsync(T category);

        public Task<bool> UpdateAsync(T category);
    }
}
