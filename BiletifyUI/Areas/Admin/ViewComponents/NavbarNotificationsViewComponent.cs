using Microsoft.AspNetCore.Mvc;

namespace BiletifyUI.Areas.Admin.ViewComponents
{
    public class NavbarNotificationsViewComponent : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View();
        }
    }
}
