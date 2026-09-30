using Microsoft.AspNetCore.Mvc;
using tdkhoa_day7.Models;

namespace tdkhoa_day7.Controllers
{
    public class ProductController : Controller
    {
        // Danh sách Category
        private static List<Category> categories = new List<Category>
        {
            new Category { Id = 1, Name = "Điện thoại" },
            new Category { Id = 2, Name = "Laptop" },
            new Category { Id = 3, Name = "Phụ kiện" },
            new Category { Id = 4, Name = "Thời trang" }
        };

        // Danh sách Product
        private static List<Product> products = new List<Product>();


        // =========================
        // DANH SÁCH SẢN PHẨM
        // =========================
        public IActionResult Index()
        {
            ViewBag.Categories = categories;

            return View(products);
        }


        // =========================
        // XEM CHI TIẾT
        // =========================
        public IActionResult Details(int id)
        {
            var product = products.FirstOrDefault(x => x.Id == id);

            if (product == null)
            {
                TempData["Error"] = "Không tìm thấy sản phẩm.";

                return RedirectToAction("Index");
            }

            ViewBag.Category = categories
                .FirstOrDefault(x => x.Id == product.CategoryId);

            return View(product);
        }


        // =========================
        // FORM THÊM
        // =========================
        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.Categories = categories;

            return View();
        }


        // =========================
        // XỬ LÝ THÊM
        // =========================
        [HttpPost]
        public async Task<IActionResult> Create(
    Product product,
    IFormFile ImageFile)
        {
            ViewBag.Categories = categories;

            // Kiểm tra có chọn ảnh hay chưa
            if (ImageFile == null || ImageFile.Length == 0)
            {
                ModelState.AddModelError(
                    "Image",
                    "Vui lòng chọn ảnh sản phẩm.");
            }

            // Image được lấy từ IFormFile nên bỏ lỗi Required của Image
            ModelState.Remove("Image");

            // Kiểm tra validation
            if (!ModelState.IsValid)
            {
                return View(product);
            }

            // Kiểm tra Category
            if (!categories.Any(x => x.Id == product.CategoryId))
            {
                ModelState.AddModelError(
                    "CategoryId",
                    "Danh mục không hợp lệ.");

                return View(product);
            }

            // Tạo tên file mới
            string fileName =
                Guid.NewGuid().ToString()
                + Path.GetExtension(ImageFile.FileName);

            // Đường dẫn wwwroot/products
            string folder = Path.Combine(
                Directory.GetCurrentDirectory(),
                "wwwroot",
                "products");

            // Tạo folder nếu chưa có
            if (!Directory.Exists(folder))
            {
                Directory.CreateDirectory(folder);
            }

            // Đường dẫn lưu ảnh
            string filePath = Path.Combine(
                folder,
                fileName);

            // Lưu ảnh
            using (var stream = new FileStream(
                filePath,
                FileMode.Create))
            {
                await ImageFile.CopyToAsync(stream);
            }

            // Tạo ID
            product.Id = products.Count == 0
                ? 1
                : products.Max(x => x.Id) + 1;

            // Lưu tên ảnh vào Product
            product.Image = fileName;

            // Thêm sản phẩm
            products.Add(product);

            TempData["Success"] =
                "Thêm sản phẩm thành công.";

            return RedirectToAction("Index");
        }


        // =========================
        // FORM SỬA
        // =========================
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var product =
                products.FirstOrDefault(x => x.Id == id);

            if (product == null)
            {
                TempData["Error"] =
                    "Không tìm thấy sản phẩm.";

                return RedirectToAction("Index");
            }

            ViewBag.Categories = categories;

            return View(product);
        }


        // =========================
        // XỬ LÝ SỬA
        // =========================
        [HttpPost]
        public async Task<IActionResult> Edit(
            Product product,
            IFormFile ImageFile)
        {
            ViewBag.Categories = categories;

            var oldProduct =
                products.FirstOrDefault(
                    x => x.Id == product.Id);

            if (oldProduct == null)
            {
                TempData["Error"] =
                    "Không tìm thấy sản phẩm.";

                return RedirectToAction("Index");
            }

            // Nếu không chọn ảnh mới
            if (ImageFile == null || ImageFile.Length == 0)
            {
                product.Image = oldProduct.Image;

                ModelState.Remove("Image");
            }

            // Kiểm tra validation
            if (!ModelState.IsValid)
            {
                return View(product);
            }

            // Kiểm tra Category
            if (!categories.Any(
                x => x.Id == product.CategoryId))
            {
                ModelState.AddModelError(
                    "CategoryId",
                    "Danh mục không hợp lệ.");

                return View(product);
            }

            // Nếu chọn ảnh mới
            if (ImageFile != null &&
                ImageFile.Length > 0)
            {
                string folder = Path.Combine(
                    Directory.GetCurrentDirectory(),
                    "wwwroot",
                    "products");

                string fileName =
                    Guid.NewGuid().ToString()
                    + Path.GetExtension(
                        ImageFile.FileName);

                string filePath =
                    Path.Combine(
                        folder,
                        fileName);

                // Lưu ảnh mới
                using (var stream =
                    new FileStream(
                        filePath,
                        FileMode.Create))
                {
                    await ImageFile.CopyToAsync(stream);
                }

                // Xóa ảnh cũ
                if (!string.IsNullOrEmpty(
                    oldProduct.Image))
                {
                    string oldPath =
                        Path.Combine(
                            folder,
                            oldProduct.Image);

                    if (System.IO.File.Exists(
                        oldPath))
                    {
                        System.IO.File.Delete(
                            oldPath);
                    }
                }

                product.Image = fileName;
            }

            // Cập nhật dữ liệu
            oldProduct.Name =
                product.Name;

            oldProduct.Image =
                product.Image;

            oldProduct.Price =
                product.Price;

            oldProduct.SalePrice =
                product.SalePrice;

            oldProduct.Description =
                product.Description;

            oldProduct.CategoryId =
                product.CategoryId;

            TempData["Success"] =
                "Cập nhật sản phẩm thành công.";

            return RedirectToAction("Index");
        }


        // =========================
        // XÓA
        // =========================
        [HttpPost]
        public IActionResult Delete(int id)
        {
            var product =
                products.FirstOrDefault(
                    x => x.Id == id);

            if (product == null)
            {
                TempData["Error"] =
                    "Không tìm thấy sản phẩm.";

                return RedirectToAction("Index");
            }

            // Xóa ảnh
            if (!string.IsNullOrEmpty(
                product.Image))
            {
                string path = Path.Combine(
                    Directory.GetCurrentDirectory(),
                    "wwwroot",
                    "products",
                    product.Image);

                if (System.IO.File.Exists(path))
                {
                    System.IO.File.Delete(path);
                }
            }

            // Xóa sản phẩm
            products.Remove(product);

            TempData["Success"] =
                "Xóa sản phẩm thành công.";

            return RedirectToAction("Index");
        }
    }
}