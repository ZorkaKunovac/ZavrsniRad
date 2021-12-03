using GamingHub2.Model;
using GamingHub2.Model.Requests;
using GamingHub2.WebApp2.Helper;
using GamingHub2.WebApp2.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace GamingHub2.WebApp2.Controllers
{
 
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        APIService _service = new APIService("Konzola");
        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public async Task<IActionResult> Index()
        {
            List<Konzola> konzolas = await _service.Get<List<Konzola>>(null);

            return View(konzolas);
        }
 
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
