using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AGLDeveloperCodeTest.Controllers
{
    public class ExceptionController : Controller
    {
        // GET: Exception
        public ActionResult Exception()
        {
            return View("Error");
        }
    }
}