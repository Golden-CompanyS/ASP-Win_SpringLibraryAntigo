using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;
using SpringLibrary.Models;

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
    }
}