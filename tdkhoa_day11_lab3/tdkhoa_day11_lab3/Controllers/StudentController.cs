using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using tdkhoa_day11_lab3.Models;

namespace tdkhoa_day11_lab3.Controllers
{
    public class StudentController : Controller
    {
        private static readonly List<Student> listStudents = new List<Student>();

        private void NapDuLieuChoForm()
        {
            ViewBag.AllBranches = Enum.GetValues(typeof(Branch))
                .Cast<Branch>()
                .Select(branch => new SelectListItem
                {
                    Value = ((int)branch).ToString(),
                    Text = branch.ToString()
                })
                .ToList();

            ViewBag.AllGenders = Enum.GetValues(typeof(Gender))
                .Cast<Gender>()
                .Select(gender => new SelectListItem
                {
                    Value = ((int)gender).ToString(),
                    Text = gender == Gender.Nam
                        ? "Nam"
                        : gender == Gender.Nu
                            ? "Nữ"
                            : "Khác"
                })
                .ToList();
        }

        public IActionResult Index()
        {
            return View(listStudents);
        }

        [HttpGet]
        public IActionResult Create()
        {
            NapDuLieuChoForm();

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Student student)
        {
            if (ModelState.IsValid)
            {
                student.Id = listStudents.Count == 0
                    ? 1
                    : listStudents.Max(s => s.Id) + 1;

                listStudents.Add(student);

                return RedirectToAction(nameof(Index));
            }

            NapDuLieuChoForm();

            return View(student);
        }
    }
}