using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using tdkhoa_day11_lab4.Data;
using tdkhoa_day11_lab4.Models;

namespace tdkhoa_day11_lab4.Controllers
{
    public class LearnerController : Controller
    {
        private readonly SchoolContext db;

    public LearnerController(SchoolContext context)
        {
            db = context;
        }

        // Hiển thị danh sách sinh viên
        public IActionResult Index()
        {
            var learners = db.Learners
                             .Include(l => l.Major)
                             .ToList();

            return View(learners);
        }

        // Nạp danh sách chuyên ngành
        private void NapDanhSachChuyenNganh()
        {
            ViewBag.MajorID = new SelectList(
                db.Majors.OrderBy(m => m.MajorName).ToList(),
                "MajorID",
                "MajorName"
            );
        }

        // GET: Learner/Create
        public IActionResult Create()
        {
            NapDanhSachChuyenNganh();

            return View();
        }

        // POST: Learner/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(
            [Bind("FirstMidName,LastName,EnrollmentDate,MajorID")] Learner learner)
        {
            if (ModelState.IsValid)
            {
                db.Learners.Add(learner);
                db.SaveChanges();

                return RedirectToAction(nameof(Index));
            }

            NapDanhSachChuyenNganh();

            return View(learner);
        }

        // GET: Learner/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var learner = db.Learners.Find(id);

            if (learner == null)
            {
                return NotFound();
            }

            NapDanhSachChuyenNganh();

            return View(learner);
        }

        // POST: Learner/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(
            int id,
            [Bind("LearnerID,FirstMidName,LastName,EnrollmentDate,MajorID")] Learner learner)
        {
            if (id != learner.LearnerID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                db.Update(learner);
                db.SaveChanges();

                return RedirectToAction(nameof(Index));
            }

            NapDanhSachChuyenNganh();

            return View(learner);
        }

        // GET: Learner/Delete/5
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var learner = db.Learners
                            .Include(l => l.Major)
                            .FirstOrDefault(l => l.LearnerID == id);

            if (learner == null)
            {
                return NotFound();
            }

            return View(learner);
        }

        // POST: Learner/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var learner = db.Learners.Find(id);

            if (learner != null)
            {
                db.Learners.Remove(learner);
                db.SaveChanges();
            }

            return RedirectToAction(nameof(Index));
        }

        // GET: Learner/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var learner = db.Learners
                            .Include(l => l.Major)
                            .Include(l => l.Enrollments)
                                .ThenInclude(e => e.Course)
                            .FirstOrDefault(l => l.LearnerID == id);

            if (learner == null)
            {
                return NotFound();
            }

            return View(learner);
        }
    }


}
