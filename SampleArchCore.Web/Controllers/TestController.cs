using Microsoft.AspNetCore.Mvc;
using SampleArch.Model;
using SampleArch.Model.Database;

namespace SampleArchCore.Web.Controllers
{
    public class TestController : Controller
    {
        private readonly SampleArchContext _context;

        public TestController(SampleArchContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var data = _context.Country.ToList();
            return View();
        }
    }
}
