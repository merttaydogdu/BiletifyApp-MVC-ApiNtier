using Microsoft.AspNetCore.Mvc;

namespace BiletifyUI.Areas.Admin.ViewComponents
{
    public class SideBarUserViewComponent : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            string userFullName = "Mert Aydoğdu";
            return View("Default",userFullName);
        }
    }
}
