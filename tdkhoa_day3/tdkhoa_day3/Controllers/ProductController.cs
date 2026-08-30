using Microsoft.AspNetCore.Mvc;
using tdkhoa_day3.Models;

namespace tdkhoa_day3.Controllers
{
    public class ProductController : Controller
    {
        // Danh sách danh mục
        private List<Category> GetCategories()
        {
            return new List<Category>
            {
                new Category { Id = 1, Name = "Quần áo" },
                new Category { Id = 2, Name = "Túi xách" },
                new Category { Id = 3, Name = "Đồng hồ" },
                new Category { Id = 4, Name = "Ti vi" },
                new Category { Id = 5, Name = "Tủ lạnh" },
                new Category { Id = 6, Name = "Máy bơm" },
                new Category { Id = 7, Name = "Quạt điện" },
                new Category { Id = 8, Name = "Lò sưởi" }
            };
        }

        // Danh sách sản phẩm
        private List<Product> GetProducts()
        {
            return new List<Product>
            {
                new Product
                {
                    Id = 1,
                    Name = "Bộ đồ bơi cho trẻ em nam",
                    Image = "/images/product1.jpg",
                    Price = 50000,
                    SalePrice = 35000,
                    CategoryId = 1,
                    Description = "Bộ đồ bơi cho trẻ em nam, chất liệu đẹp, thoải mái.",
                    Status = "Còn hàng",
                    CreatedAt = new DateTime(2021, 7, 15, 12, 0, 0)
                },

                new Product
                {
                    Id = 2,
                    Name = "Bộ đồ bơi cho trẻ em nữ",
                    Image = "/images/product2.jpg",
                    Price = 50000,
                    SalePrice = 35000,
                    CategoryId = 1,
                    Description = "Bộ đồ bơi cho trẻ em nữ, thiết kế đẹp và thoải mái.",
                    Status = "Còn hàng",
                    CreatedAt = new DateTime(2021, 7, 15, 12, 0, 0)
                },

                new Product
                {
                    Id = 3,
                    Name = "Bộ đồ bơi cho trẻ em từ 3-5 tuổi",
                    Image = "/images/product3.jpg",
                    Price = 50000,
                    SalePrice = 35000,
                    CategoryId = 1,
                    Description = "Bộ đồ bơi dành cho trẻ em từ 3 đến 5 tuổi.",
                    Status = "Còn hàng",
                    CreatedAt = new DateTime(2021, 7, 15, 12, 0, 0)
                },

                new Product
                {
                    Id = 4,
                    Name = "Bộ đồ bơi cho trẻ em thời trang",
                    Image = "/images/product4.jpg",
                    Price = 50000,
                    SalePrice = 35000,
                    CategoryId = 1,
                    Description = "Bộ đồ bơi thời trang dành cho trẻ em.",
                    Status = "Còn hàng",
                    CreatedAt = new DateTime(2021, 7, 15, 12, 0, 0)
                },

                new Product
                {
                    Id = 5,
                    Name = "Túi thời trang mẫu mới 2021",
                    Image = "/images/product5.jpg",
                    Price = 50000,
                    SalePrice = 35000,
                    CategoryId = 2,
                    Description = "Túi thời trang mẫu mới 2021, thiết kế hiện đại.",
                    Status = "Còn hàng",
                    CreatedAt = new DateTime(2021, 7, 15, 12, 0, 0)
                },

                new Product
                {
                    Id = 6,
                    Name = "Túi thời trang da cá sấu",
                    Image = "/images/product6.jpg",
                    Price = 50000,
                    SalePrice = 35000,
                    CategoryId = 2,
                    Description = "Túi thời trang da cá sấu cao cấp.",
                    Status = "Còn hàng",
                    CreatedAt = new DateTime(2021, 7, 15, 12, 0, 0)
                }
            };
        }

        // Trang danh sách sản phẩm
        public IActionResult Index(int? categoryId)
        {
            var products = GetProducts();
            var categories = GetCategories();

            // Nếu người dùng chọn danh mục
            if (categoryId.HasValue)
            {
                products = products
                    .Where(p => p.CategoryId == categoryId.Value)
                    .ToList();
            }

            var model = new ProductViewModel
            {
                Products = products,
                Categories = categories
            };

            return View(model);
        }

        // Trang chi tiết sản phẩm
        public IActionResult Detail(int id)
        {
            var product = GetProducts()
                .FirstOrDefault(p => p.Id == id);

            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }
    }
}