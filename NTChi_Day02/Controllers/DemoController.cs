using Microsoft.AspNetCore.Mvc;

namespace NTChi_Day02.Controllers
{
    public class DemoController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
