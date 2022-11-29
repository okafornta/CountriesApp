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
    }
}
