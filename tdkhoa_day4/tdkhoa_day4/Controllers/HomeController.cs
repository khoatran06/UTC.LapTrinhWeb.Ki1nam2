using Microsoft.AspNetCore.Mvc;
using tdkhoa_day4.Models;

namespace tdkhoa_day4.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            // Danh sách sản phẩm mới nhất
            var products = new List<Product>
            {
                new Product
                {
                    Id = 1,
                    Name = "Nồi cơm điện cao tần Nagakawa NAG0102",
                    Image = "/images/noicom.jpg",
                    Price = 2850000
                },

                new Product
                {
                    Id = 2,
                    Name = "Nồi cơm điện cao tần Nagakawa NAG0102",
                    Image = "/images/noicom.jpg",
                    Price = 2850000
                },

                new Product
                {
                    Id = 3,
                    Name = "Nồi cơm điện cao tần Nagakawa NAG0102",
                    Image = "/images/noicom.jpg",
                    Price = 2850000
                }
            };

            return View(products);
        }
    }
}