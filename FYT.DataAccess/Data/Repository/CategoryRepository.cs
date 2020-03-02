using FYT.DataAccess.Data.Repository.IRepository;
using FYT.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FYT.DataAccess.Data.Repository
{
    public class CategoryRepository : Repository<Category>, ICategoryRepository
    {
        private readonly ApplicationDbContext _db;

        public CategoryRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public IEnumerable<SelectListItem> GetCategoryListForDropDown()
        {
            return _db.Category.Select(c => new SelectListItem()
            {
                Value = c.Id.ToString(),
                Text = c.Name
            });
        }

        public void Update(Category category)
        {
            var objFromDb = _db.Category.FirstOrDefault(c => c.Id == category.Id);

            objFromDb.Name = category.Name;

            _db.SaveChanges();
        }
    }
}
