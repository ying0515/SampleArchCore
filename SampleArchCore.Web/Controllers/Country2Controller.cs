using Microsoft.AspNetCore.Mvc;
using SampleArch.Service.Interface;

namespace SampleArchCore.Web.Controllers
{
    public class Country2Controller : Controller
    {
        ICountryService _CountryService;

        public Country2Controller(ICountryService countryService)
        {
            _CountryService = countryService;
        }

        public IActionResult Index()
        {
            var data = _CountryService.GetAll();
            var aa = data.ToList();

            return View();
        }
    }
}
