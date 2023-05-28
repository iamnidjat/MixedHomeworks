using Microsoft.AspNetCore.Mvc;

namespace AreaWebApplication.Areas.Student.Controllers
{
	[Area("Student")]
	public class MainController : Controller
	{
		public IActionResult Index()
		{
			string str = "Hello world";

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
