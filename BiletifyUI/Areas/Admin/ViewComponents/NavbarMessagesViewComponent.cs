﻿using Microsoft.AspNetCore.Mvc;

namespace BiletifyUI.Areas.Admin.ViewComponents
{
    public class NavbarMessagesViewComponent : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View();
        }
    }
}
