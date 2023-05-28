using Cinema.Models;
using Cinema.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Cinema.Controllers
{
    public class CinemaController : Controller
    {
        private readonly ICinemaService _cinemaService;
        
        public CinemaController(ICinemaService cinemaService)
        {
            _cinemaService = cinemaService;
        }

        public IActionResult Index()
        {
            return View(_cinemaService.GetItems());
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromForm] CinemaItem cinemaItem)
        {
            if (cinemaItem == null || cinemaItem.CinemaTitle == string.Empty || cinemaItem.Description == string.Empty)
            {
                return View();
            }

            await _cinemaService.AddItemAsync(cinemaItem);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Delete([FromBody] CinemaItem cinemaItem)
        {
            if (cinemaItem == null || cinemaItem.Id <= 0)
            {
                return View();
            }

            await _cinemaService.RemoveItemAsync(cinemaItem.Id);

            return Ok();
        }

        [HttpGet]
        public IActionResult Delete()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Edit([FromForm] CinemaItem cinemaItem)
        {
            if (cinemaItem == null || cinemaItem.CinemaTitle == string.Empty || cinemaItem.Description == string.Empty)
            {
                return View();
            }

            await _cinemaService.EditItemAsync(cinemaItem);


            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            return View(_cinemaService.GetCinema(id));
        }
    }
}
