using Microsoft.AspNetCore.Mvc;

namespace AURA_Frontend.Controllers
{
    public class ServiceController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Create()
        {
            return View();
        }
    }
}
