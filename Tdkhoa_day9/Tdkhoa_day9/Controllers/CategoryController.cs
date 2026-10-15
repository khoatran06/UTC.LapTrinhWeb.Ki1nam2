using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Tdkhoa_day9.Data;
using Tdkhoa_day9.Models;

namespace Tdkhoa_day9.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CategoryController(ApplicationDbContext context)
        {
            _context = context;
        }

        // Danh sách danh mục
        public async Task<IActionResult> Index()
        {
            var danhSach = await _context.Categories.ToListAsync();
            return View(danhSach);
        }

        // Xem chi tiết
        public async Task<IActionResult> Details(int id)
        {
            var category = await _context.Categories
                .FirstOrDefaultAsync(c => c.Id == id);

            if (category == null)
            {
                return NotFound();
            }

            return View(category);
        }

        // Hiển thị form thêm
        public IActionResult Create()
        {
            return View();
        }

        // Lưu danh mục mới
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Category category)
        {
            if (await _context.Categories
                .AnyAsync(c => c.Name == category.Name))
            {
                ModelState.AddModelError("Name", "Tên danh mục đã tồn tại");
            }

            if (!ModelState.IsValid)
            {
                return View(category);
            }

            category.CreatedDate = DateTime.Today;

            _context.Categories.Add(category);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        // Hiển thị form sửa
        public async Task<IActionResult> Edit(int id)
        {
            var category = await _context.Categories.FindAsync(id);

            if (category == null)
            {
                return NotFound();
            }

            return View(category);
        }

        // Lưu thông tin sửa
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Category category)
        {
            if (id != category.Id)
            {
                return NotFound();
            }

            if (await _context.Categories
                .AnyAsync(c => c.Name == category.Name && c.Id != id))
            {
                ModelState.AddModelError("Name", "Tên danh mục đã tồn tại");
            }

            if (!ModelState.IsValid)
            {
                return View(category);
            }

            var categoryCu = await _context.Categories.FindAsync(id);

            if (categoryCu == null)
            {
                return NotFound();
            }

            categoryCu.Name = category.Name;
            categoryCu.Status = category.Status;
            categoryCu.Image = category.Image;
            categoryCu.Description = category.Description;

            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        // Hiển thị xác nhận xóa
        public async Task<IActionResult> Delete(int id)
        {
            var category = await _context.Categories.FindAsync(id);

            if (category == null)
            {
                return NotFound();
            }

            return View(category);
        }

        // Thực hiện xóa
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var category = await _context.Categories.FindAsync(id);

            if (category != null)
            {
                bool coSanPham = await _context.Products
                    .AnyAsync(p => p.CategoryId == id);

                if (coSanPham)
                {
                    ModelState.AddModelError(
                        string.Empty,
                        "Không thể xóa danh mục đang có sản phẩm.");

                    return View("Delete", category);
                }

                _context.Categories.Remove(category);
                await _context.SaveChangesAsync();
            }

            return RedirectToAction(nameof(Index));
        }
    }
}