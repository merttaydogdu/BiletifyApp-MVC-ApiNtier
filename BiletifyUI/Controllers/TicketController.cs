using Biletify.Business.Abstract;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace BiletifyUI.Controllers
{
    public class TicketController : Controller
    {
        private readonly IProductService _productManager;

        public TicketController(IProductService productManager)
        {
            _productManager = productManager;
        }

        public async Task<IActionResult> Index()
        {
            var products = await _productManager.GetAllNonDeletedAsync();
            return View(products.Data);
        }

        public async Task<IActionResult> Review(int id)
        {
            var response = await _productManager.GetByIdAsync(id);

            if (response.IsSucceeded)
            {
                return View(response.Data);
            }
            else
            {
                return NotFound();
            }
            
        }
    }
}

