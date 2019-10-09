using System;
using System.Collections.Generic;
using Console_Banco.Controllers;
using Console_Banco.Models;

namespace Console_Banco
{
    class Program
    {
        static void Main(string[] args)
        {

            // Baixamos do Nuget a biblioteca SqlClient para trabalhar com banco dentro do projeto de console
            // Criamos uma pasta Scripts
            // Dentro dela criamos um arquivo conexão seguindo os passos dentro do mesmo
            // Depois criamos uma pasta Models
            // Dentro de Models criamos nosso CadastroModel
            // Criamos uma pasta Controllers
            // Dentro de Controllers criamos CadastroController

            CadastroController cadastroController = new CadastroController();


            // Cadastramos novos dados
            CadastroModel cadastro = new CadastroModel();

            Console.Write("Digite um nome: ");
            cadastro.Nome = Console.ReadLine();

            Console.Write("Digite um email: ");
            cadastro.Email = Console.ReadLine();

            Console.WriteLine( cadastroController.Cadastrar(cadastro) );


            // Mostramos os dados cadastrados através de uma Lista
            List<CadastroModel> cadastros = new List<CadastroModel>();

            cadastros = cadastroController.Listar();

            foreach (CadastroModel c in cadastros)
            {
                Console.WriteLine(c.IdCadastro);
                Console.WriteLine(c.Nome);
                Console.WriteLine(c.Email);
                Console.WriteLine(c.DataCadastro.ToShortDateString());
                Console.WriteLine();
            }

            // Atualizar dados de um cadastro
            CadastroModel cadastro_update = new CadastroModel();

            Console.Write("Digite um ID para atualizar: ");
            cadastro_update.IdCadastro = int.Parse(Console.ReadLine());

            Console.Write("Digite um nome: ");
            cadastro_update.Nome = Console.ReadLine();

            Console.Write("Digite um email: ");
            cadastro_update.Email = Console.ReadLine();

            Console.WriteLine( cadastroController.Atualizar(cadastro_update) );


            // Excluir um dado
            Console.Write("Digite um ID para excluir: ");
            int idExcluir = int.Parse(Console.ReadLine());

            Console.WriteLine( cadastroController.Excluir(idExcluir) );

        }
    }
}
