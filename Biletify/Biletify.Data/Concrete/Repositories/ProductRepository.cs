using Biletify.Data.Abstract;
using Biletify.Data.Concrete.EfCore.Contexts;
using Biletify.Entity.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biletify.Data.Concrete.EfCore.Repositories
{
    public class ProductRepository : GenericRepository<Product>, IProductRepository
    {
        public ProductRepository(BiletifyDbContext biletifyDbContext):base(biletifyDbContext)
        {
            
        }

        private BiletifyDbContext BiletifyDbContext
        {
            get { return _dbContext as BiletifyDbContext; }
        }

        public async Task<List<Product>> GetProductsByCategoryIdAsync(int categoryId)
        {
            List<Product> products = await BiletifyDbContext
                .Products
                .Include(p => p.ProductCategories)
                .ThenInclude(pc => pc.Category)
                .Where(p => p.ProductCategories.Any(pc => pc.CategoryId == categoryId))
                .ToListAsync();
            return products;
        }

        public async Task ClearProductCategory(int productId, List<int> categoryIds)
        {
            List<ProductCategory> productCategories = await BiletifyDbContext
                .ProductCategories
                .Where(pc => pc.ProductId == productId)
                .ToListAsync();
            BiletifyDbContext.ProductCategories.RemoveRange(productCategories);
            await BiletifyDbContext.SaveChangesAsync();
        }
    }
}
