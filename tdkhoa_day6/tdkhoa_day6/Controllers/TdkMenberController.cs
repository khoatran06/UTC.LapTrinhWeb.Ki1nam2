    using Microsoft.AspNetCore.Mvc;
    using tdkhoa_day6.Models;

    namespace tdkhoa_day6.Controllers
    {
        public class TdkMenberController : Controller
        {
            private static readonly List<TdkMenber> _tdkMenbers = new List<TdkMenber>()
            {
                new TdkMenber
        {
            TdkMenberId = Guid.NewGuid().ToString(),
            TdkMenberUserName = "Khoa Tran",
            TdkMenberPassword = "123456",
            TdkMenberEmail = "trandinhkhoa2306@gmail.com",
            TdkMenberFullName = "Trần Đình Khoa"
        },

        new TdkMenber
        {
            TdkMenberId = Guid.NewGuid().ToString(),
            TdkMenberUserName = "nguyenan",
            TdkMenberPassword = "123456",
            TdkMenberEmail = "nguyenan@gmail.com",
            TdkMenberFullName = "Nguyễn Văn An"
        },

        new TdkMenber
        {
            TdkMenberId = Guid.NewGuid().ToString(),
            TdkMenberUserName = "leminh",
            TdkMenberPassword = "123456",
            TdkMenberEmail = "leminh@gmail.com",
            TdkMenberFullName = "Lê Văn Minh"
        },

        new TdkMenber
        {
            TdkMenberId = Guid.NewGuid().ToString(),
            TdkMenberUserName = "phamha",
            TdkMenberPassword = "123456",
            TdkMenberEmail = "phamha@gmail.com",
            TdkMenberFullName = "Phạm Thu Hà"
        },

        new TdkMenber
        {
            TdkMenberId = Guid.NewGuid().ToString(),
            TdkMenberUserName = "tranlong",
            TdkMenberPassword = "123456",
            TdkMenberEmail = "tranlong@gmail.com",
            TdkMenberFullName = "Trần Văn Long"
        },

        new TdkMenber
        {
            TdkMenberId = Guid.NewGuid().ToString(),
            TdkMenberUserName = "doanlinh",
            TdkMenberPassword = "123456",
            TdkMenberEmail = "doanlinh@gmail.com",
            TdkMenberFullName = "Đoàn Ngọc Linh"
        },

        new TdkMenber
        {
            TdkMenberId = Guid.NewGuid().ToString(),
            TdkMenberUserName = "hoangnam",
            TdkMenberPassword = "123456",
            TdkMenberEmail = "hoangnam@gmail.com",
            TdkMenberFullName = "Hoàng Đức Nam"
        },

        new TdkMenber
        {
            TdkMenberId = Guid.NewGuid().ToString(),
            TdkMenberUserName = "vuthao",
            TdkMenberPassword = "123456",
            TdkMenberEmail = "vuthao@gmail.com",
            TdkMenberFullName = "Vũ Thu Thảo"
        }
        };
            public IActionResult TdkAbout()
            {
                return View();
            }
            public IActionResult TdkIndex()
            {
                return View(_tdkMenbers);
            }

            public IActionResult Create()
            {
                return View();
            }

            [HttpPost]
        public IActionResult Edit(string id, TdkMenber tdkMenber)
        {
            for (int i = 0; i < _tdkMenbers.Count; i++)
            {
                if (_tdkMenbers[i].TdkMenberId == id)
                {
                    _tdkMenbers[i].TdkMenberId = tdkMenber.TdkMenberId;
                    _tdkMenbers[i].TdkMenberUserName = tdkMenber.TdkMenberUserName;
                    _tdkMenbers[i].TdkMenberPassword = tdkMenber.TdkMenberPassword;
                    _tdkMenbers[i].TdkMenberFullName = tdkMenber.TdkMenberFullName;
                    _tdkMenbers[i].TdkMenberEmail = tdkMenber.TdkMenberEmail;

                    break;
                }
            }

            return RedirectToAction("TdkIndex");
        }

        public IActionResult Edit(string id)
            {
            var tdkMenber = _tdkMenbers.FirstOrDefault(x=>x.TdkMenberId.Equals(id));
                return View(tdkMenber);
            }
            public IActionResult TdkGetDetails()
            {
                var tdkMenber = new TdkMenber()
                {
                    TdkMenberId = Guid.NewGuid().ToString(),
                    TdkMenberUserName = "Khoa Tran",
                    TdkMenberPassword = "Khoa123@",
                    TdkMenberFullName = "Tran Dinh Khoa",
                    TdkMenberEmail = "Trandinhkhoa2306@gmail.com"
                };
                return View(tdkMenber);
            }
        }
    }
