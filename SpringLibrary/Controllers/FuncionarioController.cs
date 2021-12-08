using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SpringLibrary.Models;
using SpringLibrary.Repositorio;
using System.Web.Mvc;

namespace SpringLibrary.Controllers
{
    public class FuncionarioController : Controller
    {

        //Ação para chamar as Views de Funcionário 
        // GET: Funcionario
        public ActionResult FuncionarioView()
        {
            var funcio = new Funcionario();
            return View(funcio);
        }

        Acoes ac = new Acoes();

        [HttpPost]

        //Cadastrando funcionário

        public ActionResult CadastrarFuncionario(Funcionario funcio)
        {
            ac.CadastrarFuncionario(funcio);
            return View("Resultado", funcio);
        }

        //Consultando Funcionário

        public ActionResult ConsultarFuncionario()
        {
            var ExibirFunc = new Acoes();
            var TodosFunc = ExibirFunc.ListarFunc();
            return View(TodosFunc);
        }
    }
}