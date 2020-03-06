using FYT.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace FYT.DataAccess.Data.Repository.IRepository
{
    public interface IImageRepository : IRepository<Image>
    {
        void update(Image image);

    }
}
