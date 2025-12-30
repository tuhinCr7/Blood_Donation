using Microsoft.AspNetCore.Mvc;

namespace CSproject.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            var role = HttpContext.Session.GetString("Role");
            if (role == "Admin") return RedirectToAction("Dashboard", "Admin");
            if (role == "Donor") return RedirectToAction("Profile", "Donor");
            if (role == "Patient") return RedirectToAction("Search", "Patient");

            return View();
        }
    }
}