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

        //Alterando dados do Funcionário 

        [HttpGet]

        public ActionResult FuncionarioAlterar(int cd)
        {
            var FuncCod = ac.ListarFuncCod(cd);
            if (FuncCod == null)
            {
                return HttpNotFound();
            }
            return View(FuncCod);
        }

        [HttpPost]

        public ActionResult FuncionarioAlterar(Funcionario funcio)
        {
            ac.FuncionarioAlterar(funcio);
            return (RedirectToAction("ConsultarFuncionario"));
        }

        //Excluir dados do funcionário

        public ActionResult FuncionarioExcluir(int cd)
        {
            ac.FuncionarioExcluir(cd);
            return View();
        }
    }
}