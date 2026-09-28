using Microsoft.AspNetCore.Mvc;
using tdkhoa_day7_demo.Models.DataModels;
using tdkhoa_day7_demo.Models.ViewModels;

namespace tdkhoa_day7_demo.Controllers
{
    public class MemberController : Controller
    {
        public static readonly List<Member> members = new List<Member>();

        public IActionResult Index()
        {
            return View(members);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(RegisterViewModel register)
        {
            if (ModelState.IsValid)
            {
                Member m = new Member
                {
                    MemberId = Guid.NewGuid().ToString(),
                    UserName = register.UserName,
                    FullName = register.FullName,
                    Email = register.Email,
                    Password = register.Password,
                    Phone = register.Phone,
                    Birthday = register.Birthday,
                };
                members.Add(m);
                return RedirectToAction("Index");
            }
            else
            {
                return View(register);
            }
        }
    }
}