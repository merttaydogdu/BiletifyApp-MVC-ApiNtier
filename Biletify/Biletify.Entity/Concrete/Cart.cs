using Biletify.Entity.Abstract;
using Biletify.Entity.Concrete.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biletify.Entity.Concrete
{
    public class Cart : IMainEntity
    {
        public int Id { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public string? UserId { get; set; }
        public User? User { get; set; }
        public List<CartItem> CartItems { get; set; } = new List<CartItem>();
        public decimal TotalPrice() 
        {
            return CartItems.Sum(x => x.Product.Price * x.Quantity);
        }
    }
}
