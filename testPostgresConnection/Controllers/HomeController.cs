using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using testPostgresConnection.DAL;
using testPostgresConnection.DAL.Interfaces;
using testPostgresConnection.DAL.Repositories;
using testPostgresConnection.Domain.Entities;
using testPostgresConnection.Models;

namespace testPostgresConnection.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IBaseRepository<Account> _accountRepository;

        public HomeController(ILogger<HomeController> logger,IBaseRepository<Account> AccountRepository)
        {
            _logger = logger;
            _accountRepository = AccountRepository;
        }

        public async Task<IActionResult> Index()
        {
            return View(_accountRepository.GetAll().AsEnumerable());
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