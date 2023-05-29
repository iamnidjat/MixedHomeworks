using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;

namespace WebApplication1.Pages
{
    public class IndexModel : PageModel
    {
        private Random rnd = new();

        private readonly ILogger<IndexModel> _logger;

        private int Position { get; set; }

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
            ViewData["DateTimeTotalDays"] = ShowDateTime();
            ViewData["ASCIIChar"] = ShowChar();
            ViewData["Position"] = Position;
        }

        public int ShowDateTime()
        {
            DateTime end = DateTime.Now;
            DateTime start = new(DateTime.Now.Year, 1, 1);

            return (int)(end - start).TotalDays;
        }

        public string ShowChar()
        {
            Position = rnd.Next(65, 91);

            char character = (char)Position;
            string text = character.ToString();

            return text;
        }
    }
}