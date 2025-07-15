// Classe Livro: representa um livro da biblioteca e contém métodos para manipulação no banco de dados.
// Segue o padrão ensinado nas aulas, com métodos estáticos para cada operação CRUD e relatórios.
using System;
using MySql.Data.MySqlClient;
using CSharpCrud.Data;

namespace CSharpCrud.Models
{
    public class Livro
    {
        // Propriedades do livro, correspondem aos campos da tabela no banco de dados.
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Autor { get; set; }
        public string Editora { get; set; }
        public int Ano { get; set; }
        public string ISBN { get; set; }
        public string Genero { get; set; }

        // Preenche os dados do livro a partir de um resultado do banco de dados.
        public void PreencherLivro(MySqlDataReader resultado)
        {
            this.Id = Convert.ToInt32(resultado["id"]);
            this.Titulo = resultado["titulo"].ToString();
            this.Autor = resultado["autor"].ToString();
            this.Editora = resultado["editora"].ToString();
            this.Ano = Convert.ToInt32(resultado["ano"]);
            this.ISBN = resultado["isbn"].ToString();
            this.Genero = resultado["genero"].ToString();
        }

        // Exibe os dados do livro no console, formatado.
        public void Mostrar()
        {
            Console.WriteLine($"{Id}\t{Titulo}\t{Autor}\t{Editora}\t{Ano}\t{ISBN}\t{Genero}");
        }

        // Lista todos os livros cadastrados no banco de dados.
        public static void ListarLivros()
        {
            MySqlConnection cn = BdComum.FazerConexao();
            cn.Open();
            MySqlCommand cmd = new MySqlCommand("SELECT * FROM livros", cn);
            MySqlDataReader resultado = cmd.ExecuteReader();

            Console.WriteLine("Id\tTítulo\tAutor\tEditora\tAno\tISBN\tGênero");
            while (resultado.Read())
            {
                Livro livro = new Livro();
                livro.PreencherLivro(resultado);
                livro.Mostrar();
            }
            resultado.Close();
            cn.Close();
        }

        // Insere um novo livro no banco de dados.
        public static void InserirLivro(Livro novo)
        {
            // Validação dos campos obrigatórios.
            if (string.IsNullOrWhiteSpace(novo.Titulo) ||
                string.IsNullOrWhiteSpace(novo.Autor) ||
                string.IsNullOrWhiteSpace(novo.Editora) ||
                novo.Ano <= 0 ||
                string.IsNullOrWhiteSpace(novo.ISBN) ||
                string.IsNullOrWhiteSpace(novo.Genero))
            {
                Console.WriteLine("Todos os campos são obrigatórios e devem ser preenchidos corretamente.");
                return;
            }

            MySqlConnection cn = BdComum.FazerConexao();
            cn.Open();
            MySqlCommand cmd = new MySqlCommand(
                "INSERT INTO livros (titulo, autor, editora, ano, isbn, genero) VALUES (@titulo, @autor, @editora, @ano, @isbn, @genero)", cn);
            cmd.Parameters.AddWithValue("@titulo", novo.Titulo);
            cmd.Parameters.AddWithValue("@autor", novo.Autor);
            cmd.Parameters.AddWithValue("@editora", novo.Editora);
            cmd.Parameters.AddWithValue("@ano", novo.Ano);
            cmd.Parameters.AddWithValue("@isbn", novo.ISBN);
            cmd.Parameters.AddWithValue("@genero", novo.Genero);

            cmd.ExecuteNonQuery();
            cn.Close();
            Console.WriteLine("Livro inserido com sucesso!");
        }

        // Busca livros pelo título (parcial).
        public static void BuscarLivro(string titulo)
        {
            MySqlConnection cn = BdComum.FazerConexao();
            cn.Open();
            MySqlCommand cmd = new MySqlCommand("SELECT * FROM livros WHERE titulo LIKE @titulo", cn);
            cmd.Parameters.AddWithValue("@titulo", "%" + titulo + "%");
            MySqlDataReader resultado = cmd.ExecuteReader();

            if (resultado.HasRows)
            {
                Console.WriteLine("Id\tTítulo\tAutor\tEditora\tAno\tISBN\tGênero");
                while (resultado.Read())
                {
                    Livro livro = new Livro();
                    livro.PreencherLivro(resultado);
                    livro.Mostrar();
                }
            }
            else
            {
                Console.WriteLine("Nenhum livro encontrado com esse título.");
            }
            resultado.Close();
            cn.Close();
        }

        // Exclui um livro pelo id.
        public static void ExcluirLivro(int id)
        {
            MySqlConnection cn = BdComum.FazerConexao();
            cn.Open();

            // Primeiro, busca o livro para mostrar ao usuário.
            MySqlCommand cmdBusca = new MySqlCommand("SELECT * FROM livros WHERE id=@id", cn);
            cmdBusca.Parameters.AddWithValue("@id", id);
            MySqlDataReader resultado = cmdBusca.ExecuteReader();

            if (resultado.HasRows)
            {
                resultado.Read();
                Livro livro = new Livro();
                livro.PreencherLivro(resultado);
                livro.Mostrar();
                resultado.Close();

                Console.Write("Deseja realmente excluir este livro? (S/N): ");
                string resp = Console.ReadLine();
                if (resp.ToUpper() == "S")
                {
                    MySqlCommand cmdDel = new MySqlCommand("DELETE FROM livros WHERE id=@id", cn);
                    cmdDel.Parameters.AddWithValue("@id", id);
                    cmdDel.ExecuteNonQuery();
                    Console.WriteLine("Livro excluído com sucesso!");
                }
            }
            else
            {
                Console.WriteLine("Livro não encontrado.");
                resultado.Close();
            }
            cn.Close();
        }

        // Altera os dados de um livro existente.
        public static void AlterarLivro(int id)
        {
            MySqlConnection cn = BdComum.FazerConexao();
            cn.Open();

            // Busca o livro pelo id.
            MySqlCommand cmdBusca = new MySqlCommand("SELECT * FROM livros WHERE id=@id", cn);
            cmdBusca.Parameters.AddWithValue("@id", id);
            MySqlDataReader resultado = cmdBusca.ExecuteReader();

            if (resultado.HasRows)
            {
                resultado.Read();
                Livro livro = new Livro();
                livro.PreencherLivro(resultado);
                livro.Mostrar();
                resultado.Close();

                // Solicita novos dados ao usuário.
                Console.Write("Novo título (deixe em branco para manter): ");
                string titulo = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(titulo)) livro.Titulo = titulo;

                Console.Write("Novo autor (deixe em branco para manter): ");
                string autor = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(autor)) livro.Autor = autor;

                Console.Write("Nova editora (deixe em branco para manter): ");
                string editora = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(editora)) livro.Editora = editora;

                Console.Write("Novo ano (deixe em branco para manter): ");
                string anoStr = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(anoStr) && int.TryParse(anoStr, out int ano) && ano > 0)
                    livro.Ano = ano;

                Console.Write("Novo ISBN (deixe em branco para manter): ");
                string isbn = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(isbn)) livro.ISBN = isbn;

                Console.Write("Novo gênero (deixe em branco para manter): ");
                string genero = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(genero)) livro.Genero = genero;

                // Atualiza no banco.
                MySqlCommand cmdAlt = new MySqlCommand(
                    "UPDATE livros SET titulo=@titulo, autor=@autor, editora=@editora, ano=@ano, isbn=@isbn, genero=@genero WHERE id=@id", cn);
                cmdAlt.Parameters.AddWithValue("@titulo", livro.Titulo);
                cmdAlt.Parameters.AddWithValue("@autor", livro.Autor);
                cmdAlt.Parameters.AddWithValue("@editora", livro.Editora);
                cmdAlt.Parameters.AddWithValue("@ano", livro.Ano);
                cmdAlt.Parameters.AddWithValue("@isbn", livro.ISBN);
                cmdAlt.Parameters.AddWithValue("@genero", livro.Genero);
                cmdAlt.Parameters.AddWithValue("@id", livro.Id);

                cmdAlt.ExecuteNonQuery();
                Console.WriteLine("Livro alterado com sucesso!");
            }
            else
            {
                Console.WriteLine("Livro não encontrado.");
                resultado.Close();
            }
            cn.Close();
        }

        // Relatório: mostra a quantidade total de livros cadastrados.
        public static void QuantidadeTotalLivros()
        {
            MySqlConnection cn = BdComum.FazerConexao();
            cn.Open();
            MySqlCommand cmd = new MySqlCommand("SELECT COUNT(*) FROM livros", cn);
            int total = Convert.ToInt32(cmd.ExecuteScalar());
            Console.WriteLine($"Quantidade total de livros cadastrados: {total}");
            cn.Close();
        }

        // Relatório: lista livros publicados após um ano informado.
        public static void ListarLivrosAposAno(int ano)
        {
            MySqlConnection cn = BdComum.FazerConexao();
            cn.Open();
            MySqlCommand cmd = new MySqlCommand("SELECT * FROM livros WHERE ano > @ano", cn);
            cmd.Parameters.AddWithValue("@ano", ano);
            MySqlDataReader resultado = cmd.ExecuteReader();

            if (resultado.HasRows)
            {
                Console.WriteLine("Id\tTítulo\tAutor\tEditora\tAno\tISBN\tGênero");
                while (resultado.Read())
                {
                    Livro livro = new Livro();
                    livro.PreencherLivro(resultado);
                    livro.Mostrar();
                }
            }
            else
            {
                Console.WriteLine("Nenhum livro encontrado após o ano informado.");
            }
            resultado.Close();
            cn.Close();
        }
    }
}
