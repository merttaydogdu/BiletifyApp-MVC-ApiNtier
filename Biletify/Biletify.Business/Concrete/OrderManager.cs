using Biletify.Business.Abstract;
using Biletify.Data.Abstract;
using Biletify.Entity.Concrete;
using Biletify.Entity.Concrete.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biletify.Business.Concrete
{
    public class OrderManager : IOrderService
    {
        private readonly IOrderRepository _orderRepository;

        public OrderManager(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public async Task CreateAsync(Order order)
        {
            await _orderRepository.CreateAsync(order);
        }

        public async Task<List<Order>> GetAllOrderAsync(string? userId = null)
        {
            var orders = await _orderRepository.GetAllAsync(userId != null ? x => x.UserId == userId : null,source=>source.Include(x=>x.OrderDetails).ThenInclude(y=>y.Product));
            return orders;
        }

        public async Task<Order> GetOrderAsync(int orderId)
        {
            var order = await _orderRepository.GetByIdAsync( x => x.Id == orderId, source => source.Include(x => x.OrderDetails).ThenInclude(y => y.Product));
            return order;
        }
    }
}
