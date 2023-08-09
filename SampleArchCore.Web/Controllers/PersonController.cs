using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SampleArch.Model;
using SampleArch.Model.Database.POCO;
using SampleArch.Service.Interface;

namespace SampleArchCore.Web.Controllers
{
    public class PersonController : Controller
    {
        IPersonService _PersonService;
        ICountryService _CountryService;

        public PersonController(IPersonService PersonService, ICountryService CountryService)
        {
            _PersonService = PersonService;
            _CountryService = CountryService;
        }

        // GET: Person
        public IActionResult Index()
        {
            return View(_PersonService.GetAll());
        }

        // GET: Person/Details/5
        public IActionResult Details(long? id)
        {
            if (id == null)
            {
                return new StatusCodeResult((int)HttpStatusCode.BadRequest);
            }
            Person person = _PersonService.GetById(id.Value);
            if (person == null)
            {
                return NotFound();
            }
            return View(person);
        }

        // GET: Person/Create
        public IActionResult Create()
        {
            ViewBag.CountryId = new SelectList(_CountryService.GetAll(), "Id", "Name");
            return View();
        }

        // POST: Person/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("Name,Phone,Address,State,CountryId,Id")] Person person)
        {
            if (ModelState.IsValid)
            {
                _PersonService.Create(person);
                return RedirectToAction(nameof(Index));
            }
            ViewBag.CountryId = new SelectList(_CountryService.GetAll(), "Id", "Name", person.CountryId);
            return View(person);
        }

        // GET: Person/Edit/5
        public IActionResult Edit(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            Person person = _PersonService.GetById(id.Value);
            if (person == null)
            {
                return NotFound();
            }
            ViewBag.CountryId = new SelectList(_CountryService.GetAll(), "Id", "Name", person.CountryId);
            return View(person);
        }

        // POST: Person/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(long id, [Bind("Name,Phone,Address,State,CountryId,Id")] Person person)
        {
            if (id != person.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _PersonService.Update(person);
                }
                catch (DbUpdateConcurrencyException)
                {
                    throw;
                }
                return RedirectToAction(nameof(Index));
            }
            ViewBag.CountryId = new SelectList(_CountryService.GetAll(), "Id", "Name", person.CountryId);
            return View(person);
        }

        // GET: Person/Delete/5
        public IActionResult Delete(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            Person person = _PersonService.GetById(id.Value);
            if (person == null)
            {
                return NotFound();
            }
            return View(person);
        }

        // POST: Person/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(long id)
        {
            Person person = _PersonService.GetById(id);
            if (person == null)
            {
                return Problem("Entity set 'SampleArchContext.Persons'  is null.");
            }
            _PersonService.Delete(person);
            return RedirectToAction(nameof(Index));
        }

    }
}
