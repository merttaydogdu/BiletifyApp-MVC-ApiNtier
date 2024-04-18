using Biletify.Data.Abstract;
using Biletify.Data.Concrete.EfCore.Contexts;
using Biletify.Data.Concrete.EfCore.Repositories;
using Biletify.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biletify.Data.Concrete.Repositories
{
    public class OrderRepository : GenericRepository<Order>, IOrderRepository
    {
        public OrderRepository(BiletifyDbContext _context):base(_context)
        {
            
        }
        BiletifyDbContext BiletifyDbContext
        {
            get { return _dbContext as BiletifyDbContext; }
        }
    }
}
