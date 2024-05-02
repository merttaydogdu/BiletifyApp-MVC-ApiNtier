using Biletify.Business.Abstract;
using Biletify.Shared.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Text.Json;


namespace BiletifyUI.Controllers
{
    public class HomeController : Controller
    {
        private readonly IProductService _productManager;

        public HomeController(IProductService productManager)
        {
            _productManager = productManager;
        }

        public async Task<IActionResult> Index()
        {
            var response = await _productManager.GetAllNonDeletedAsync();

            if (!response.IsSucceeded)
            {
                return View("Error");
            }

            var allProducts = response.Data;

            int musicCategoryId = 3;

            var musicResponse = await _productManager.GetProductsByCategoryIdAsync(musicCategoryId);

            if (!musicResponse.IsSucceeded)
            {
                return View("Error");
            }

            var musicProducts = musicResponse.Data;

            var featuredProducts = allProducts
                .Where(p => p.IsHome)
                .ToList();

            var viewModel = new HomePageViewModel
            {
                FeaturedProducts = featuredProducts,
                MusicProducts = musicProducts
            };

            return View(viewModel);
        }

        public IActionResult AboutUs()
        {
            return View();
        }
    }
}
