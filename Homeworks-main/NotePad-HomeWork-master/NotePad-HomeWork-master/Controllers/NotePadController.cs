using Microsoft.AspNetCore.Mvc;
using NotePad.Models;
using NotePad.Services;

namespace NotePad.Controllers
{
    public class NotePadController : Controller
    {
        private readonly INotePad _notePad;

        public NotePadController(INotePad notePad)
        {
            _notePad = notePad;
        }

        public IActionResult Index()
        {
            ViewData["NotePad"] = _notePad.GetItems();

            return View();
        }

        [HttpPost]
        public IActionResult AddItem(string? title, string? description, DateTime date, string? tag)
        {
            if (string.IsNullOrWhiteSpace(title) || string.IsNullOrWhiteSpace(description) || string.IsNullOrWhiteSpace(tag) || date.Date < DateTime.Today)
            {
                return BadRequest();
            }

            _notePad.AddItem(new()
            {
                Title = title,
                Description = description,
                Created = date,
                Tags = tag
            });

            return Ok();
        }

        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult RemoveItem(string? index)
        {
            if (index.Any(c => char.IsLetter(c)) || string.IsNullOrWhiteSpace(index) || int.Parse(index) < 1)
            {
                return BadRequest();
            }

            _notePad.RemoveItem(int.Parse(index) - 1);

            return Ok();
        }

        public IActionResult Remove()
        {
            return View();
        }

        [HttpPost]
        public IActionResult EditItem(string? index, string? title, string? description, DateTime date, string? tag)
        {
            if (index.Any(c => char.IsLetter(c)) || string.IsNullOrWhiteSpace(index) || string.IsNullOrWhiteSpace(title) || string.IsNullOrWhiteSpace(description) || string.IsNullOrWhiteSpace(tag) || date.Date < DateTime.Today)
            {
                return BadRequest();
            }

            _notePad.EditItem(int.Parse(index) - 1, new()
            {
                Title = title,
                Description = description,
                Created = date,
                Tags = tag
            });

            return Ok();
        }

        public IActionResult Edit()
        {
            return View();
        }
    }
}
