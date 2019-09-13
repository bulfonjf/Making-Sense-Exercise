using Microsoft.AspNetCore.Mvc;

namespace Client.Controllers
{
    public class AuthorizationController : Controller
    {
        public IActionResult AccessDenied()
        {
            return View();
        }
    }
}
