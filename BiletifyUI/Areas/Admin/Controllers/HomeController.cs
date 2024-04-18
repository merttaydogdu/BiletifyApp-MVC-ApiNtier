using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BiletifyUI.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin, Moderator")]
    [Area("Admin")]
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }


    }
}
