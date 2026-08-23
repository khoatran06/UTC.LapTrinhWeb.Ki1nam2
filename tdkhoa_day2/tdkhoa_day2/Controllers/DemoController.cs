using Microsoft.AspNetCore.Mvc;

namespace tdkhoa_day2.Controllers
{
    public class DemoController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
