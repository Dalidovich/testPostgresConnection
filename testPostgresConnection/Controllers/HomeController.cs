using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using testPostgresConnection.DAL;
using testPostgresConnection.Models;

namespace testPostgresConnection.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly AppDBContext _appDBContext;

        public HomeController(ILogger<HomeController> logger,AppDBContext appDBContext)
        {
            _logger = logger;
            _appDBContext = appDBContext;
        }

        public IActionResult Index()
        {
            return View(_appDBContext.user.AsEnumerable());
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}