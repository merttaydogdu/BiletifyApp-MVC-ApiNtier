using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biletify.Business.Abstract
{
    public interface ICartItemService
    {
        Task ClearCartAsync(int cartId);
        Task DeleteItemFromCartAsync(int cartItemId);
        Task ChangeQuantityAsync(int cartItemId, int quantity);
        Task<int> ItemCountAsync(int cartId);
        Task AddCartItemToCartAsync(string userId, int productId, int quantity);
    }
}
