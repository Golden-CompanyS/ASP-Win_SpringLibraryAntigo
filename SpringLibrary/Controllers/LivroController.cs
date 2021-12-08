using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SpringLibrary.Models;
using System.Web.Mvc;

namespace SpringLibrary.Controllers
{
    public class LivroController : Controller
    {
        // GET: Livro
        public ActionResult LivroView()
        {
            var livro = new Livro();
            return View(livro);
        }
    }
}