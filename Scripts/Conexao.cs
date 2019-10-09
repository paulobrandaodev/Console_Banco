using System.Data.SqlClient;

namespace Console_Banco.Scripts {
    public class Conexao {

        // 1 - Instancio o meu objeto de conexão
        SqlConnection con = new SqlConnection ();

        public Conexao () {
            // 2 - Defino os dados de conexão com meu servidor SQL
            con.ConnectionString = @"Data Source=DESKTOP-XVGT587\SQLEXPRESS;Initial Catalog=teste;Integrated Security=True";
            // string de conexão com Usuário e Senha
            // con.ConnectionString = @"Data Source=DESKTOP-XVGT587\SQLEXPRESS;Initial Catalog=teste;User Id=sa;Password=132";
        }

        public SqlConnection Conectar () {
            // 3 - Verifico se a conexão está fechada para conectar ao banco
            if (con.State == System.Data.ConnectionState.Closed) {
                con.Open ();
            }
            return con;
        }

        public void Desconectar () {
            // 4 - Verifico se a conexão está aberta para fechar a conexão
            if (con.State == System.Data.ConnectionState.Open) {
                con.Close ();
            }
        }

    }
}