using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SpringLibrary.Models;
using System.Web.Mvc;

namespace SpringLibrary.Controllers
{
    public class EnderecoController : Controller
    {
        // GET: Endereco
        public ActionResult EnderecoView()
        {
            var endereco = new Endereco();
            return View(endereco);
        }
    }
}