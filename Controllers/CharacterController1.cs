using character.Models;
using Microsoft.AspNetCore.Mvc;

namespace character.Controllers
{
    public class CharacterController1 : Controller
    {
        private Characters context { get; set; }

        public CharacterController1(Characters ctx)
        {
            context = ctx;
        }

        [HttpGet]
        public IActionResult Add()
        {
            ViewBag.Action = "Add";
            ViewBag.Class = context.Names.OrderBy(g => g.Name).ToList();
            return View("Edit", new Name());
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            ViewBag.Action = "Edit";
            ViewBag.Genres = context.Names.OrderBy(g => g.Name).ToList();
            var movie = context.Names.Find(id);
            return View(movie);
        }
        [HttpPost]
        public IActionResult Edit(Name name)
        {
            if (ModelState.IsValid)
            {
                if (name.CharacterId == 0)
                    context.Names.Add(name);
                else
                    context.Names.Update(name);
                context.SaveChanges();
                return RedirectToAction("Index", "Home");

            }
            else
            {
                ViewBag.Action = (name.CharacterId == 0) ? "Add" : "Edit";
                ViewBag.Genres = context.Names.OrderBy(g => g.Name).ToList();
                return View(name);
            }
        }
        [HttpGet]
        public IActionResult Delete(int id)
        {
            var movie = context.Names.Find(id);
            return View(movie);
        }
        [HttpPost]
        public IActionResult Delete(Name name)
        {
            context.Names.Remove(name);
            context.SaveChanges();
            return RedirectToAction("Index", "Home");
        }

    }
}