using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SpringLibrary.Models;
using System.Web.Mvc;

namespace SpringLibrary.Controllers
{
    public class DeliveryController : Controller
    {
        // GET: Delivery
        public ActionResult DeliveryView()
        {
            var deliv = new Delivery();
            return View(deliv);
        }
    }
}