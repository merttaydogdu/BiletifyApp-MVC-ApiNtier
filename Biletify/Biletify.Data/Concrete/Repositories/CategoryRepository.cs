using Biletify.Data.Abstract;
using Biletify.Data.Concrete.EfCore.Contexts;
using Biletify.Data.Concrete.EfCore.Repositories;
using Biletify.Entity.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biletify.Data.Concrete.Repositories
{
    public class CategoryRepository : GenericRepository<Category>, ICategoryRepository
    {
        public CategoryRepository(BiletifyDbContext biletifyDbContext):base(biletifyDbContext)
        {
            
        }
        private BiletifyDbContext BiletifyDbContext
        {
            get {return _dbContext as BiletifyDbContext;}
        }

        public async Task<List<Category>> GetActiveCategoriesAsync(bool isActive = true)
        {
            var categories = await BiletifyDbContext
                .Categories
                .Where(c => c.IsActive == isActive && !c.IsDeleted)
                .ToListAsync();
            return categories;
        }

        public async Task<List<Category>> GetAllNonDeletedAsync(bool isDeleted = false)
        {
            var categories = await BiletifyDbContext
                .Categories
                .Where(c => c.IsDeleted == isDeleted)
                .ToListAsync();
            return categories;
        }
    }
}
