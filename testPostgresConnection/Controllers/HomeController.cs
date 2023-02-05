using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using testPostgresConnection.DAL;
using testPostgresConnection.DAL.Interfaces;
using testPostgresConnection.DAL.Repositories;
using testPostgresConnection.Domain.Entities;
using testPostgresConnection.Models;
using testPostgresConnection.Service.Interfaces;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace testPostgresConnection.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IAccountService _accountService;

        public HomeController(ILogger<HomeController> logger, IAccountService accountService)
        {
            _logger = logger;
            _accountService = accountService;
        }

        public async Task<IActionResult> Index()
        {
            var response = await _accountService.GetAll();
            if (response.StatusCode == Domain.Enums.StatusCode.AccountRead)
            {
                return View(response.Data);
            }
            return RedirectToAction("Error");
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