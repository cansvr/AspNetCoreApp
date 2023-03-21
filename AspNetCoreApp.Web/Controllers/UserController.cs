using Microsoft.AspNetCore.Mvc;

namespace AspNetCoreApp.Web.Controllers
{
    public class User
    {
        public int ID { get; set; }
        public string Name { get; set; }
    }

    public class UserController : Controller
    {
        public IActionResult Index()
        {
            var userList = new List<User>()
            {
                new(){ID = 1, Name="Can"},
                new(){ID = 2, Name="Mustafa"},
                new(){ID = 3, Name="Merve"},
            };

            ViewBag.name = "NET Core";

            ViewData["age"] = 30;

            ViewData["names"] = new List<string>() { "Ahment", "Mehmet" };

            ViewBag.person = new { Id = 1, Name = "ahmet", Age = 23 };

            TempData["surname"] = "sever";

            return View(userList);
        }

        public IActionResult Index2()
        {
            var surName = TempData["surname"];

            return View();
        }

        public IActionResult Index3()
        {
            return RedirectToAction("Index", "User");
        }

        public IActionResult ParametreView(int id)
        {
            return RedirectToAction("JsonResultParametre", "User", new { id = id });
        }

        public IActionResult JsonResultParametre(int id)
        {
            return Json(new { Id = id });
        }

        public IActionResult ContentResult()
        {
            return Content("test");
        }

        public IActionResult JsonResult()
        {
            return Json(new { Id = 1, name = "can", surname = "sever" });
        }

        public IActionResult EmptyResult()
        {
            return new EmptyResult();
        }
    }
}
