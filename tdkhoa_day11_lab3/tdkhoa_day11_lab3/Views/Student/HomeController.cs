using Microsoft.AspNetCore.Mvc;

namespace tdkhoa_day11_lab3.Views.Student
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
