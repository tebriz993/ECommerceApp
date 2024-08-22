using Microsoft.AspNetCore.Mvc;

namespace Tech.ECommerce.UI.Areas.AdminArea.ViewComponents
{
    public class SideBarViewComponent: ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View();
        }
    }
}
