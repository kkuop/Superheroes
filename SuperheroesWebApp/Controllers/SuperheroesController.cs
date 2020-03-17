using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SuperheroesWebApp.Data;
using SuperheroesWebApp.Models;

namespace SuperheroesWebApp.Controllers
{
    public class SuperheroesController : Controller
    {
        private ApplicationDbContext _context { get; }
        public SuperheroesController(ApplicationDbContext context)
        {
            _context = context;
        }
        // GET: Superheroes
        public ActionResult Index()
        {
            var superheroes = _context.Superhero.Select(a => a);
            return View(superheroes);
        }

        // GET: Superheroes/Details/5
        public ActionResult Details(int id)
        {
            Superhero superhero = _context.Superhero.First(a => a.SuperheroId == id);
            return View(superhero);
        }

        // GET: Superheroes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Superheroes/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Superhero superhero)
        {
            try
            {
                // TODO: Add insert logic here
                _context.Superhero.Add(superhero);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Superheroes/Edit/5
        public ActionResult Edit(int id)
        {
            try
            {
                var superhero = _context.Superhero.First(a => a.SuperheroId == id);
                return View(superhero);
            }
            catch
            {
                return View();
            }
        }

        // POST: Superheroes/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Superhero superhero)
        {
            try
            {
                // TODO: Add update logic here
                Superhero foundSuperhero = _context.Superhero.First(a => a.SuperheroId == id);
                foundSuperhero.Name = superhero.Name;
                foundSuperhero.PrimaryAbility = superhero.PrimaryAbility;
                foundSuperhero.SecondaryAbility = superhero.SecondaryAbility;
                foundSuperhero.AlterEgo = superhero.AlterEgo;
                foundSuperhero.Catchphrase = superhero.Catchphrase;
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Superheroes/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Superheroes/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}