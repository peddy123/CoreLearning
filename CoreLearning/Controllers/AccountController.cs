using Microsoft.AspNetCore.Mvc;

namespace CoreLearning.Controllers
{
    public class AccountController : Controller
    {
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }
    }
}
