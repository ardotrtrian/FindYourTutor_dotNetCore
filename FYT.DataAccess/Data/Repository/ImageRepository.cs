using FYT.DataAccess.Data.Repository.IRepository;
using FYT.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FYT.DataAccess.Data.Repository
{
    public class ImageRepository : Repository<Image>, IImageRepository
    {
        private readonly ApplicationDbContext _db;

        public ImageRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }
        
        public void update(Image image)
        { 
            var objFromDb = _db.Image.FirstOrDefault(i => i.Id == image.Id);

            objFromDb.URL = image.URL;

            _db.SaveChanges();
        }
    }
}
