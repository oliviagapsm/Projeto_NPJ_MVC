using Microsoft.AspNetCore.Mvc;

namespace NPJ_MVC.Controllers
{
    public class Login : Controller
    {
        public IActionResult IndexLogin()
        {
            return View();
        }
    }
}
