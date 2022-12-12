using CountriesApp.Data;
using CountriesApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CountriesApp.Controllers
{
    public class CountryController : Controller
    {
        private readonly CountryDbContext _db;
        public CountryController(CountryDbContext db)
        {
            _db = db;
        }

        
        public async Task<IActionResult> Index()
        {
            return View(await _db.Countries.ToListAsync());
        }


        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Country country)
        {
            _db.Add(country);
            await _db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        // Get: countries details
        public async Task<IActionResult> Details(int? id)
        {
            if(id == null)
            {
                return NotFound();
            }
            var country = await _db.Countries
                .FirstOrDefaultAsync(m => m.Id ==id);
            if(country == null)
            {
                return NotFound();
            }
            return View(country);
        }
        
        // Get: Creating Editing side
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var country = await _db.Countries.FindAsync(id);
            if (country == null)
            {
                return NotFound();
            }
            return View();
        }

        // Creating another edit and protecting from over posting 
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Capital,Population,Economy,Currency")] Country country)
        {
            if (id != country.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _db.Update(country);
                    await _db.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CountryExists(country.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(country);
        }

        private bool CountryExists(int id)
        {
            throw new NotImplementedException();
        }

        //Creating Countries/Delete/
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var country = await _db.Countries
                .FirstOrDefaultAsync(m => m.Id == id);
            if (country == null)
            {
                return NotFound();
            }

            return View(country);
        }
        // POST: Countries/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var countries = await _db.Countries.FindAsync(id);
            _ = _db.Countries.Remove(countries);
            await _db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CountryExists(int? id)
        {
            return _db.Countries.Any(e => e.Id == id);
        }

    }
}
