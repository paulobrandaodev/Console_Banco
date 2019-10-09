using System;

namespace Console_Banco.Models
{
    public class CadastroModel
    {
        public int IdCadastro { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public DateTime DataCadastro { get; set; }
    }
}