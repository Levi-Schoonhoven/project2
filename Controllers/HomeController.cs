using character.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
//using MovieList.Models;'
using Microsoft.EntityFrameworkCore;

namespace chpt4x1.Controllers
{
    public class HomeController : Controller
    {
        private Characters context { get; set; }

        public HomeController(Characters ctx)
        {
            context = ctx;
        }

        public IActionResult Index()
        {
            var character = context.Names.Include(m => m.CharacterId).OrderBy(m => m.Name).ToList();
            return View(character);
        }


    }
}