// Classe responsável por centralizar a conexão com o banco de dados MySQL.
// Aqui, criamos um método estático que retorna uma conexão pronta para uso.
// O padrão é o mesmo ensinado nas aulas, facilitando o uso em outros arquivos.
using MySql.Data.MySqlClient;

namespace CSharpCrud.Data
{
    public static class BdComum
    {
        // Retorna uma conexão aberta com o banco de dados MySQL.
        public static MySqlConnection FazerConexao()
        {
            // String de conexão padrão: servidor local, banco 'aulas', usuário 'root', senha vazia.
            MySqlConnection conexao = new MySqlConnection("server=127.0.0.1; database=aulas; uid=root; pwd=;");
            return conexao;
        }
    }
}
