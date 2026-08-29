using Microsoft.AspNetCore.Mvc;

namespace Chi_Day03.Controllers
{
    public class DemoController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
