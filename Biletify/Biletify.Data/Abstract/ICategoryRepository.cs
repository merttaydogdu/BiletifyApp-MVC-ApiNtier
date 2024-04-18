using Biletify.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biletify.Data.Abstract
{
    public interface ICategoryRepository : IGenericRepository<Category>
    {
        //category entitysine özel metot imzalar bulunur
        Task<List<Category>> GetAllNonDeletedAsync(bool isDeleted = false);
        Task<List<Category>> GetActiveCategoriesAsync(bool isActive = true);
    }
}
