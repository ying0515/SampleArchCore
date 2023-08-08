using Microsoft.AspNetCore.Mvc;
using SampleArch.Model;
using SampleArch.Service.Interface;

namespace SampleArchCore.Web.Controllers
{
    public class CountryController : Controller
    {
        private readonly SampleArchContext _context;

        public CountryController(SampleArchContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var data = _context.Countries.ToList();
            return View();
        }

    }
}
