using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SpringLibrary.Models;
using System.Web.Mvc;

namespace SpringLibrary.Controllers
{
    public class RestauracaoController : Controller
    {
        // GET: Restauracao
        public ActionResult RestauracaoView()
        {
            var restau = new Restauracao();
            return View(restau);
        }
    }
}