using Microsoft.AspNetCore.Mvc;
using tdkhoa_day4.Models;

namespace tdkhoa_day4.ViewComponents
{
    public class HotProductViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            var products = new List<Product>
            {
                new Product
                {
                    Id = 4,
                    Name = "Nồi cơm điện cao tần Nagakawa NAG0102",
                    Image = "/images/noicom.jpg",
                    Price = 2850000
                },

                new Product
                {
                    Id = 5,
                    Name = "Nồi cơm điện cao tần Nagakawa NAG0102",
                    Image = "/images/noicom.jpg",
                    Price = 2850000
                },

                new Product
                {
                    Id = 6,
                    Name = "Nồi cơm điện cao tần Nagakawa NAG0102",
                    Image = "/images/noicom.jpg",
                    Price = 2850000
                }
            };

            return View(products);
        }
    }
}