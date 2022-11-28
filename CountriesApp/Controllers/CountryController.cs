using Microsoft.AspNetCore.Mvc;

namespace CountriesApp.Controllers
{
    public class CountryController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
