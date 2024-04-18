using Biletify.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biletify.Business.Abstract
{
    public interface IOrderService
    {
        Task CreateAsync(Order order);
        Task<Order> GetOrderAsync(int orderId);
        Task<List<Order>> GetAllOrderAsync(string? userId = null);
    }
}
