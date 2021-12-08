using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;
using SpringLibrary.Models;
using System.Data;

namespace SpringLibrary.Repositorio
{
    public class Acoes
    {
        Conexao con = new Conexao();

        // METÓDO QUE TESTA SE O USUARIO E SENHA E VÁLIDO NO BANCO DE DADOS E LEVA PARA O VERIFICA USUARIO
        public Funcionario TestarFunc(Funcionario f)
        {
            MySqlCommand cmd = new MySqlCommand("select * from tbFuncionario where funcNome =@funcionario and funcSenha =@senha",
            con.ConectarBD());
            cmd.Parameters.Add("@funcionario", MySqlDbType.VarChar).Value = f.funcNome;
            cmd.Parameters.Add("@senha", MySqlDbType.VarChar).Value = f.funcSenha;

            MySqlDataReader leitor;

            leitor = cmd.ExecuteReader();

            if(leitor.HasRows)
            {
                while (leitor.Read())
                {
                    Funcionario dto = new Funcionario();
                    {
                        dto.funcNome = Convert.ToString(leitor["FUNCNOME"]);
                        dto.funcSenha = Convert.ToString(leitor["FUNCSENHA"]);
                    }
                }
            }
            else
            {
                f.funcNome = null;
                f.funcSenha = null;
            }
            return f;
        }

        //Cadastrar Funcionário
        public void CadastrarFuncionario(Funcionario funcio)
        {
            MySqlCommand cmd = new MySqlCommand("insert into tbfuncionario values(@funcCod, @funcNome, @funcNomeSoc, " +
                "@funcCargo, @funcSenha)", con.ConectarBD());
            cmd.Parameters.Add("@funcCod", MySqlDbType.Int32).Value = funcio.funcCod;
            cmd.Parameters.Add("@funcNome", MySqlDbType.VarChar).Value = funcio.funcNome;
            cmd.Parameters.Add("@funcNomeSoc", MySqlDbType.VarChar).Value = funcio.funcNomeSoc;
            cmd.Parameters.Add("@funcCargo", MySqlDbType.VarChar).Value = funcio.funcCargo;
            cmd.Parameters.Add("@funcSenha", MySqlDbType.VarChar).Value = funcio.funcSenha;
            cmd.ExecuteNonQuery();
            con.DesconectarBD();
        }

        //Consultar Funcionário

        public List<Funcionario> ListarFunc()
        {
            MySqlCommand cmd = new MySqlCommand("select * from tbFuncionario", con.ConectarBD());
            var DadosFunc = cmd.ExecuteReader();
            return ListarFunc(DadosFunc);
        }

        //listando pelo código

        public Funcionario ListarFuncCod(int cd)
        {
            var comando = string.Format("select * from tbFuncionario where funcCod = {0}", cd);
            MySqlCommand cmd = new MySqlCommand(comando, con.ConectarBD());
            var DadosFuncCod = cmd.ExecuteReader();
            return ListarFunc(DadosFuncCod).FirstOrDefault();
        }

        public List<Funcionario> ListarFunc(MySqlDataReader dr)
        {
            var AltFunc = new List<Funcionario>();
            while(dr.Read())
            {
                var FuncTemp = new Funcionario()
                {
                    funcCod = int.Parse(dr["funcCod"].ToString()),
                    funcNome = dr["funcNome"].ToString(),
                    funcNomeSoc = dr["funcNomeSoc"].ToString(),
                    funcCargo = dr["funcCargo"].ToString(),
                    funcSenha = dr["funcSenha"].ToString(),
                };

                AltFunc.Add(FuncTemp);
            }

            dr.Close();
            return AltFunc;
        }

        //Alterando funcionário 

        public void FuncionarioAlterar(Funcionario funcio)
        {
            MySqlCommand cmd = new MySqlCommand("update tbFuncionario set funcNome=@funcNome, funcNomeSoc=@funcNomeSoc, funcCargo=@funcCargo, funcSenha=@funcSenha where funcCod=@funcCod", con.ConectarBD());
            cmd.Parameters.Add("@funcCod", MySqlDbType.Int32).Value = funcio.funcCod;
            cmd.Parameters.Add("@funcNome", MySqlDbType.VarChar).Value = funcio.funcNome;
            cmd.Parameters.Add("@funcNomeSoc", MySqlDbType.VarChar).Value = funcio.funcNomeSoc;
            cmd.Parameters.Add("@funcCargo", MySqlDbType.VarChar).Value = funcio.funcCargo;
            cmd.Parameters.Add("@funcSenha", MySqlDbType.VarChar).Value = funcio.funcSenha;
            cmd.ExecuteNonQuery();
            con.DesconectarBD();
        }

        //Excluir funcionário

        public void FuncionarioExcluir(int cd)
        {
            var comando = string.Format("delete from tbFuncionario where funcCod={0}", cd);
            MySqlCommand cmd = new MySqlCommand(comando, con.ConectarBD());
            cmd.ExecuteReader();
        }
    }
}