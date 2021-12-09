using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SpringLibrary.Models;
using SpringLibrary.Repositorio;
using System.Web.Mvc;

namespace SpringLibrary.Controllers
{
    public class ClienteController : Controller
    {

        //Metódo  para abrir as classes. 
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

        Acoes ac = new Acoes();

        [HttpPost]

        //Cadastrar cliente físico 

        public ActionResult CadastrarCliFis(Cliente cli)
        {
            ac.CadastrarCliFis(cli);
            return View("ResultadoCliFis", cli);
        }

        //Cadastrar cliente jurídico 

        public ActionResult CadastrarCliJur(Cliente cli)
        {
            ac.CadastrarCliJur(cli);
            return View("ResultadoCliJur", cli);
        }

        //Listar clientes

        public ActionResult ConsultarCliente()
        {
            var ExibirCli = new Acoes();
            var TodosCli = ExibirCli.ListarCliente();
            return View(TodosCli);
        }

        //Alterar clientes

        //Excluir clientes

    }
}