using Biletify.Business.Abstract;
using Biletify.Data.Abstract;
using Biletify.Entity.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biletify.Business.Concrete
{
    public class CartItemManager : ICartItemService
    {
        private readonly ICartItemRepository _cartItemRepository;
        private readonly ICartRepository _cartRepository;

        public CartItemManager(ICartItemRepository cartItemRepository, ICartRepository cartRepository)
        {
            _cartItemRepository = cartItemRepository;
            _cartRepository = cartRepository;
        }

        public async Task AddCartItemToCartAsync(string userId, int productId, int quantity)
        {
            var cart = await _cartRepository.GetByIdAsync(x => x.UserId == userId, y=>y.Include(z=>z.CartItems));
            if (cart != null)
            {
                int index = cart.CartItems.FindIndex(x => x.ProductId == productId);
                if (index < 0 )
                {
                    cart.CartItems.Add(new CartItem
                    {
                        ProductId = productId,
                        Quantity = quantity,
                        CartId = cart.Id
                    });
                }
                else
                {
                    cart.CartItems[index].Quantity += quantity;
                }
                await _cartRepository.UpdateAsync(cart);

            }
        }
        public async Task ChangeQuantityAsync(int cartItemId, int quantity)
        {
            CartItem cartItem = await _cartItemRepository.GetByIdAsync(x=>x.Id==cartItemId);
            cartItem.Quantity = quantity;
            await _cartItemRepository.UpdateAsync(cartItem);
        }

        public async Task ClearCartAsync(int cartId)
        {
            Cart cart = await _cartRepository.GetByIdAsync(x => x.Id == cartId);
            cart.CartItems = new List<CartItem>();
            await _cartRepository.UpdateAsync(cart);

        }

        public async Task DeleteItemFromCartAsync(int cartItemId)
        {
            CartItem cartItem = await _cartItemRepository.GetByIdAsync(x => x.Id == cartItemId);
            await _cartItemRepository.HardDeleteAsync(cartItem);
        }

        public async Task<int> ItemCountAsync(int cartId)
        {
            int count = await _cartItemRepository.GetCountAsync(x => x.CartId == cartId);
            return count;
        }
    }
}
