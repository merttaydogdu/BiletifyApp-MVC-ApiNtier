using Biletify.Business.Abstract;
using Biletify.Data.Concrete.EfCore.Contexts;
using Biletify.Entity.Concrete;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace BiletifyUI.Controllers
{
    public class TicketController : Controller
    {
        private readonly IProductService _productManager;
        private readonly BiletifyDbContext _context;

        public TicketController(IProductService productManager, BiletifyDbContext context)
        {
            _productManager = productManager;
            _context = context;
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
        private Product GetRandomProductFromDatabase()
        {
            var products = _context.Products.ToList();
            var random = new Random();
            var randomIndex = random.Next(products.Count);
            var randomProduct = products[randomIndex];
            return randomProduct;
        }

        public async Task<IActionResult> RollDice()
        {
            var randomProduct = GetRandomProductFromDatabase(); 
            return View(randomProduct);
        }
    }
}

