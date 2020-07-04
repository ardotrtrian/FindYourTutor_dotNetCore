using FYT.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FYT.BusinessLogic.IBusinessRules
{
    public interface IRatingBusinessRules<T> : IBusinessRules<T> where T : Rating
    {
        //public Task<IEnumerable<Rating>> GetAllAsync();

        public Task<IEnumerable<Rating>> GetAllAsync(int courseId);

        //public Task<Rating> GetAsync(int id);

        //public Task<bool> DeleteAsync(int id);
  
        //public Task<Rating> CreateAsync(Rating rating);

        //public Task<bool> UpdateAsync(Rating rating);
    }
}
