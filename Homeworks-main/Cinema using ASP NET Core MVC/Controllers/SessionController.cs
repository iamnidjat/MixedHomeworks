using Cinema.Models;
using Cinema.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Cinema.Controllers
{
    public class SessionController : Controller
    {
        private readonly ISessionService _sessionService;

        public SessionController(ISessionService sessionService)
        {
           _sessionService = sessionService;
        }

        public IActionResult Index()
        {
            return View(_sessionService.GetItems());
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromForm] SessionItem? sessionItem)
        {
            if (sessionItem == null || sessionItem.Title == string.Empty || sessionItem.ShowDate < DateTime.Now)
            {
                return View();
            }

            await _sessionService.AddItemAsync(sessionItem);


            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Add()
        {
            SelectList cinemas = new (_sessionService.GetCinemas(), "Id", "CinemaTitle");
            ViewBag.Cinemas = cinemas;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Delete([FromBody] SessionItem sessionItem)
        {
            if (sessionItem == null || sessionItem.Id <= 0)
            {
                return View();
            }

            await _sessionService.RemoveItemAsync(sessionItem.Id);

            return Ok();
        }
                           
        [HttpGet]
        public IActionResult Delete()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Edit([FromForm] SessionItem? sessionItem)
        {
            if (sessionItem == null || sessionItem.Title == string.Empty || sessionItem.ShowDate < DateTime.Now)
            {
                return View();
            }

            await _sessionService.EditItemAsync(sessionItem);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            return View(_sessionService.GetSession(id));
        }
    }
}
