using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SpringLibrary.Models;
using System.Web.Mvc;

namespace SpringLibrary.Controllers
{
    public class EventoController : Controller
    {
        // GET: Evento
        public ActionResult EventoView()
        {
            var evento = new Locacao();
            return View(evento);
        }
    }
}