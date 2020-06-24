using FYT.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FYT.BusinessLogic.IBusinessRules
{
    public interface ICategoryBusinessRules<T> where T : Category
    {
        public Task<IEnumerable<Category>> GetAllAsync();

        public Task<Category> GetAsync(int id);

        public Task<bool> DeleteAsync(int id);

        public Task<Category> CreateAsync(Category category);
        
        public Task<bool> UpdateAsync(Category category); 
    }
}
