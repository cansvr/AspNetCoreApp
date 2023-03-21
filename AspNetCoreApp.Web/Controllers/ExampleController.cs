using Microsoft.AspNetCore.Mvc;

namespace AspNetCoreApp.Web.Controllers
{
    public class ExampleController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult NoLayout()
        {
            return View();
        }
    }
}
