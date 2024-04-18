using Biletify.Business.Abstract;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BiletifyUI.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin, Moderator")]
    [Area("Admin")]
    public class OrderController : Controller
    {
        private readonly IOrderService _orderManager;

        public OrderController(IOrderService orderManager)
        {
            _orderManager = orderManager;
        }

        public async Task<IActionResult> Index()
        {
            var orders = await _orderManager.GetAllOrderAsync();
            return View(orders);
        }
    }
}
