using AGLDeveloperCodeTest.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AGLDeveloperCodeTest.Controllers
{
    public class PeoplePetsController : Controller
    {
        private IProcessJsonDataService _Service;

        public PeoplePetsController()
        {
            _Service = new ProcessJsonDataService();
        }

        public PeoplePetsController(IProcessJsonDataService parseJsonService)
        {
            _Service = parseJsonService;
        }
        // GET: PeoplePets
        public ActionResult PeoplePets()
        {
            return View();
        }
    }
}