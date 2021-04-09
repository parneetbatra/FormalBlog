using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FormalBlog.Controllers
{
    [Authorize]
    public class DashboardController : Controller
    {
        [Route("Dashboard")]
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
    }
}
