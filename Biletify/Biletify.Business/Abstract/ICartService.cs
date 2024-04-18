using Biletify.Entity.Concrete;
using Biletify.Shared.ResponseViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biletify.Business.Abstract
{
    public interface ICartService
    {
        Task InitializeCartAsync(string userId);
        Task<Cart> GetCartByUserIdAsync(string userId);
    }
}
