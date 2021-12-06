using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SpringLibrary.Repositorio;
using SpringLibrary.Models;
using System.Web.Security;

namespace SpringLibrary.Controllers
{
    public class LoginController : Controller
    {
        Acoes ac = new Acoes();
        // GET: Login
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]

        public ActionResult VerificarFunc(Funcionario f)
        {
            ac.TestarFunc(f);

            if(f.funcNome != null && f.funcSenha != null)
            {
                FormsAuthentication.SetAuthCookie(f.funcNome, false);
                Session["funcionarioLogado"] = f.funcNome.ToString();
                Session["senhaLogada"] = f.funcSenha.ToString();

                return RedirectToAction("Index", "Home");
            }
            else
            {
                return RedirectToAction("Login", "Login");
            }
        }

        public ActionResult Logout()
        {
            Session["funcionarioLogado"] = null;

           return RedirectToAction("Login", "Login");

        }
    }
}