using FYT.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace FYT.BusinessLogic.IBusinessRules
{
    public interface ICategoryBusinessRules<T> where T : Category
    {
        public IEnumerable<Category> GetAll();

        public Category GetById(int id);

        public bool Delete(int id);

        public void Create(Category category);
        
        public bool Update(Category category); 
    }
}
