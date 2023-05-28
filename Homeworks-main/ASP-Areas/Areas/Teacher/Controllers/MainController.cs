using Microsoft.AspNetCore.Mvc;

namespace AreaWebApplication.Areas.Teacher.Controllers
{
    [Area("Teacher")]
    public class MainController : Controller
    {
        public IActionResult Index()
        {
            string str = "Bye world";

            return View
            (
                model: str
            );
        }

        public IActionResult Info()
        {
            return View();
        }
    }
}
