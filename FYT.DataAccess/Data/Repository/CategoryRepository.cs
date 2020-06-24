using FYT.DataAccess.Data.Repository.IRepository;
using FYT.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public async Task<bool> UpdateAsync(Category category)
        {
            var objFromDb = await _db.Category.FirstOrDefaultAsync(c => c.Id == category.Id);

            if (objFromDb == null)
            {
                return false;
            }
            objFromDb.Name = category.Name;

            await _db.SaveChangesAsync();
            return true;
        }
    }
}
