using Microsoft.AspNetCore.Mvc;
using WebApplication2.Services;

namespace WebApplication2.Controllers
{
    [Route("user")]
    public class RouteController : Controller
    {
        private readonly IUsersManager _usermanager;

        public RouteController(IUsersManager usermanager)
        {
            _usermanager = usermanager;
        }

        [Route("main")]
        public IActionResult Index()
        {
            return View();
        }

        [Route("get/{id:int?}")]
        public string Get(int? id)
        {
            return $"User:\nId: {_usermanager?.GetUserById(id)?.Id}\nFirstname: {_usermanager?.GetUserById(id)?.FirstName}\n" +
                $"Lastname: {_usermanager?.GetUserById(id)?.LastName}\nMail: {_usermanager?.GetUserById(id)?.Mail}\n" +
                $"Gender: {_usermanager?.GetUserById(id)?.Gender}\n";
        }
    }
}
