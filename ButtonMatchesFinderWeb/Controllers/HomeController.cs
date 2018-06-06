using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ButtonMatchesFinderWeb.Models;
using HtmlAgilityPack;
using ButtonMatchesFinderWeb.Services;

namespace ButtonMatchesFinderWeb.Controllers
{
    public class HomeController : Controller
    {
        private IFinderService FinderService;

        public HomeController(IFinderService finderService)
        {
            FinderService = finderService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Find(FindModel model)
        {
            var web = new HtmlWeb();
            var originalDoc = web.Load(model.OriginUrl);
            var originalNode = originalDoc.GetElementbyId(model.OriginId);
            if (originalNode == null)
                throw new Exception("Element not found");

            var sampleDoc = web.Load(model.SampleUrl);
            var sampleNodes = sampleDoc.DocumentNode.Descendants();

            var result = FinderService.Find(sampleNodes, originalNode);
            if (result.Element == null)
                throw new Exception("No matching elements");
            return View(result);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
