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

    }
}
