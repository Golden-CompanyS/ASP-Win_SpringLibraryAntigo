using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SpringLibrary.Models;
using System.Web.Mvc;

namespace SpringLibrary.Controllers
{
    public class ClienteController : Controller
    {
        // GET: Cliente
        public ActionResult ClienteFisico()
        {
            var clientefis = new Cliente();
            return View(clientefis);
        }

        public ActionResult ClienteJuridico()
        {
            var clientejur = new Cliente();
            return View(clientejur);
        }
    }
}