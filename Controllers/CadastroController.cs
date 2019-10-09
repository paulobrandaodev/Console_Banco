using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Console_Banco.Models;
using Console_Banco.Scripts;

namespace Console_Banco.Controllers {
    public class CadastroController {

        // 1 - Instanciamos nossa classe de Conexão
        Conexao conexao = new Conexao ();

        // 2 - Chamamos nosso objeto que dará os comandos SQL
        SqlCommand cmd = new SqlCommand ();



        // 3 - Criamos um método do tipo Lista de Cadastro
        public List<CadastroModel> Listar () {

            // 4 -  Conecto com o banco
            cmd.Connection = conexao.Conectar ();

            // 5 - Preparo minha Query 
            cmd.CommandText = "SELECT * FROM cadastro";

            // 6 - Executo o comando para ler
            SqlDataReader dados = cmd.ExecuteReader ();

            // 7 - Crio uma lista para exibir meus cadastros
            List<CadastroModel> cadastros = new List<CadastroModel> ();

            while (dados.Read ()) {
                cadastros.Add (
                    new CadastroModel () {
                        IdCadastro = Convert.ToInt32 (dados.GetValue (0)),
                        Nome = dados.GetValue (1).ToString (),
                        Email = dados.GetValue (2).ToString (),
                    }
                );
            }

            // 7 - Desconectar
            conexao.Desconectar ();

            return cadastros;

        }

        // -- Criamos nossométodo de Cadastro
        public string Cadastrar(CadastroModel dado)
        {   
            string mensagem = "";

            try
            {
                // 9 -  Conecto com o banco
                cmd.Connection = conexao.Conectar();

                // 10 - Preparo minha Query 
                cmd.CommandText = "INSERT INTO cadastro (Nome, Email) VALUES (@nome, @email)";
                cmd.Parameters.AddWithValue("@nome" , dado.Nome);
                cmd.Parameters.AddWithValue("@email", dado.Email);

                // 11 - Executo o comando
                cmd.ExecuteNonQuery();

                // 12 - Desconectar
                conexao.Desconectar();

                // 13 - Mostrar MSG de sucesso
                mensagem = "Cadastrado com sucesso!";


            }
            catch (System.Exception ex)
            {                
                mensagem = "Erro ao tentar se conectar com o banco de dados: " + ex;
            }

            return mensagem;

        }

        // -- Criamos nosso método para Atualização
        public string Atualizar(CadastroModel dado)
        {   
            string mensagem = "";

            try
            {
                // 9 -  Conecto com o banco
                cmd.Connection = conexao.Conectar();

                // 10 - Preparo minha Query 
                cmd.CommandText = "UPDATE cadastro SET Nome=@nome, Email=@email WHERE IdCadastro=@id";
                cmd.Parameters.AddWithValue("@nome" , dado.Nome);
                cmd.Parameters.AddWithValue("@email", dado.Email);
                cmd.Parameters.AddWithValue("@id",    dado.IdCadastro);

                // 11 - Executo o comando
                cmd.ExecuteNonQuery();

                // 12 - Desconectar
                conexao.Desconectar();

                // 13 - Mostrar MSG de sucesso
                mensagem = "Alterado com sucesso!";


            }
            catch (System.Exception ex)
            {                
                mensagem = "Erro ao tentar se conectar com o banco de dados: " + ex;
            }

            return mensagem;

        }

        // -- Criamos nosso método para excluir um cadastro
        public string Excluir(int id){
            string mensagem = "";

            try
            {
                // 9 -  Conecto com o banco
                cmd.Connection = conexao.Conectar();

                // 10 - Preparo minha Query 
                cmd.CommandText = "DELETE FROM cadastro WHERE IdCadastro=@id";
                cmd.Parameters.AddWithValue("@id" , id);

                // 11 - Executo o comando
                cmd.ExecuteNonQuery();

                // 12 - Desconectar
                conexao.Desconectar();

                // 13 - Mostrar MSG de sucesso
                mensagem = "Excluído com sucesso!";


            }
            catch (System.Exception ex)
            {                
                mensagem = "Erro ao tentar se conectar com o banco de dados: " + ex;
            }

            return mensagem;
        }

    }
}