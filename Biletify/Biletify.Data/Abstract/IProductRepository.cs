﻿using Biletify.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biletify.Data.Abstract
{
    public interface IProductRepository : IGenericRepository<Product>
    {
        Task<List<Product>> GetProductsByCategoryIdAsync(int categoryId);
        Task ClearProductCategory(int productId, List<int> categoryIds);

    }
}
