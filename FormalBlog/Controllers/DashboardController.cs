using Microsoft.AspNetCore.Mvc;

namespace FormalBlog.Controllers
{
    public class DashboardController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
