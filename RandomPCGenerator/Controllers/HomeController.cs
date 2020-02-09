using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RandomPCGenerator.Models;
using RandomPCGenerator.Processors;

namespace RandomPCGenerator.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult RandomChr()
        {
            ViewData["CharacterClass"] = CharacterClassProcessor.GetRandomCharacterClass(20);
            ViewData["Background"] = PersonalityProcessor.randomBackground();
            ViewData["Stats"] = RandomStats.RandomTheNumbers();
            RangeTable rt = new RangeTable();
            rt.AddEntry(1,8,"Autocracy");
            rt.AddEntry(9, 13, "Beureaucracy");
            rt.AddEntry(14, 19, "Confederacy");
            ViewData["Govt"] = rt.Roll();

            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
