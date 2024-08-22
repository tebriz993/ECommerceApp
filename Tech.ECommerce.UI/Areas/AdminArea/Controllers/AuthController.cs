using Microsoft.AspNetCore.Mvc;

namespace Tech.ECommerce.UI.Areas.AdminArea.Controllers
{
    public class AuthController : Controller
    {
        public IActionResult Register()
        {
            return View();
        }
    }
}
