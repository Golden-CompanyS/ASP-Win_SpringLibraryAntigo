using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SpringLibrary.Models;
using System.Web.Mvc;

namespace SpringLibrary.Controllers
{
    public class ItemVendaController : Controller
    {
        // GET: ItemVenda
        public ActionResult ItemVendaView()
        {
            var itemv = new ItemVenda();
            return View(itemv);
        }
    }
}