using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SampleArch.Model;
using SampleArch.Model.Database.POCO;
using SampleArch.Service.Interface;

namespace SampleArchCore.Web.Controllers
{
    public class CountryController : Controller
    {
        ICountryService _CountryService;

        public CountryController(ICountryService CountryService)
        {
            _CountryService = CountryService;
        }

        // GET: Country
        public IActionResult Index()
        {
              return _CountryService.GetAll() != null ? 
                          View(_CountryService.GetAll()) :
                          Problem("Entity set 'SampleArchContext.Countries'  is null.");
        }

        // GET: Country/Details/5
        public IActionResult Details(int? id)
        {
            Country country = _CountryService.GetById(Convert.ToInt32(id));
            if (id == null || country == null)
            {
                return NotFound();
            }
            return View(country);
        }

        // GET: Country/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Country/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        //public IActionResult Create([Bind("Name,Id")] Country country)
        public IActionResult Create(Country country)
        {
            //country.Persons = new List<Person>();
            IEnumerable <ModelError> allErrors = ModelState.Values.SelectMany(v => v.Errors);
            if (ModelState.IsValid)
            //if (true)
            {
                _CountryService.Create(country);
                return RedirectToAction(nameof(Index));
            }
            return View(country);
        }

        // GET: Country/Edit/5
        public IActionResult Edit(int? id)
        {
            Country country = _CountryService.GetById(Convert.ToInt32(id));
            if (id == null || country == null)
            {
                return NotFound();
            }
            return View(country);
        }

        // POST: Country/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("Name,Id")] Country country)
        {
            if (id != country.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _CountryService.Update(country);
                }
                catch (DbUpdateConcurrencyException)
                {
                    throw;
                }
                return RedirectToAction(nameof(Index));
            }
            return View(country);
        }

        // GET: Country/Delete/5
        public IActionResult Delete(int? id)
        {
            Country country = _CountryService.GetById(Convert.ToInt32(id));
            if (id == null || country == null)
            {
                return NotFound();
            }
            return View(country);
        }

        // POST: Country/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            Country country = _CountryService.GetById(id);
            if (country == null)
            {
                return Problem("Entity set 'SampleArchContext.Countries'  is null.");
            }
            _CountryService.Delete(country);
            return RedirectToAction(nameof(Index));
        }
    }
}
