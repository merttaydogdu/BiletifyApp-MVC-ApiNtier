using Biletify.Entity.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biletify.Entity.Concrete
{
    public class CartItem : IMainEntity
    {
        public int Id { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public int Quantity { get; set; }
        public int ProductId { get; set; }
        public Product? Product { get; set; }
        public int CartId { get; set; }
        public Cart? Cart { get; set; }
    }
}
