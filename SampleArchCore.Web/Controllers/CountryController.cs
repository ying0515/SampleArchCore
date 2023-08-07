using Microsoft.AspNetCore.Mvc;
using SampleArch.Model;
using SampleArch.Service.Interface;

namespace SampleArchCore.Web.Controllers
{
    public class CountryController : Controller
    {
        //initialize service object
        ICountryService _CountryService;

        public CountryController(ICountryService countryService)
        {
            _CountryService = countryService;
        }

        public IActionResult Index()
        {
            var data = _CountryService.GetAll();
            var aa = data.ToList();

            //using (var db = new SampleArchContext())
            //{
            //    var data = db.Countries.ToList();
            //    var ss = "123";
            //}

            return View();
        }

    }
}
