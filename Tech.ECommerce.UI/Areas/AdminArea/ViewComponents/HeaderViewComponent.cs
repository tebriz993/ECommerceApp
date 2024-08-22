using Microsoft.AspNetCore.Mvc;

namespace Tech.ECommerce.UI.Areas.AdminArea.ViewComponents
{
    public class HeaderViewComponent:ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View();
        }
    }
}
