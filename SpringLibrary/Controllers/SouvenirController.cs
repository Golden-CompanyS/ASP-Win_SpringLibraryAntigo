using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SpringLibrary.Models;
using System.Web.Mvc;

namespace SpringLibrary.Controllers
{
    public class SouvenirController : Controller
    {
        // GET: Souvenir
        public ActionResult SouvenirView()
        {
            var souvenir = new Souvenir();
            return View(souvenir);

        }
    }
}