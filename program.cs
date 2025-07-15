// Programa principal do sistema de cadastro de livros de biblioteca.
// Este arquivo contém o menu textual e a lógica de interação com o usuário.
// Segue o padrão ensinado nas aulas, com comentários detalhados para facilitar o entendimento.

using System;

class Program
{
    static void Main(string[] args)
    {
        int opcao = -1;
        while (opcao != 0)
        {
            // Exibe o menu principal
            Console.WriteLine("\n===== SISTEMA DE CADASTRO DE LIVROS =====");
            Console.WriteLine("1 - Listar todos os livros");
            Console.WriteLine("2 - Buscar livro por título");
            Console.WriteLine("3 - Inserir novo livro");
            Console.WriteLine("4 - Alterar livro existente");
            Console.WriteLine("5 - Excluir livro");
            Console.WriteLine("6 - Relatório: quantidade total de livros");
            Console.WriteLine("7 - Relatório: listar livros publicados após ano informado");
            Console.WriteLine("0 - Sair");
            Console.Write("Escolha uma opção: ");

            // Tenta ler a opção do usuário, tratando possíveis erros de digitação
            try
            {
                opcao = int.Parse(Console.ReadLine());
            }
            catch (FormatException)
            {
                Console.WriteLine("Opção inválida! Digite um número.");
                opcao = -1;
                continue;
            }

            // Executa a operação escolhida
            switch (opcao)
            {
                case 1:
                    // Lista todos os livros cadastrados
                    Livro.ListarLivros();
                    break;
                case 2:
                    // Busca livros pelo título
                    Console.Write("Digite o título para buscar: ");
                    string tituloBusca = Console.ReadLine();
                    Livro.BuscarLivro(tituloBusca);
                    break;
                case 3:
                    // Insere um novo livro
                    Livro novo = new Livro();
                    Console.Write("Título: ");
                    novo.Titulo = Console.ReadLine();
                    Console.Write("Autor: ");
                    novo.Autor = Console.ReadLine();
                    Console.Write("Editora: ");
                    novo.Editora = Console.ReadLine();
                    Console.Write("Ano de publicação: ");
                    if (!int.TryParse(Console.ReadLine(), out int ano) || ano <= 0)
                    {
                        Console.WriteLine("Ano inválido! Operação cancelada.");
                        break;
                    }
                    novo.Ano = ano;
                    Console.Write("ISBN: ");
                    novo.ISBN = Console.ReadLine();
                    Console.Write("Gênero: ");
                    novo.Genero = Console.ReadLine();
                    Livro.InserirLivro(novo);
                    break;
                case 4:
                    // Altera um livro existente
                    Console.Write("Digite o id do livro a alterar: ");
                    if (!int.TryParse(Console.ReadLine(), out int idAlt) || idAlt <= 0)
                    {
                        Console.WriteLine("Id inválido! Operação cancelada.");
                        break;
                    }
                    Livro.AlterarLivro(idAlt);
                    break;
                case 5:
                    // Exclui um livro
                    Console.Write("Digite o id do livro a excluir: ");
                    if (!int.TryParse(Console.ReadLine(), out int idExc) || idExc <= 0)
                    {
                        Console.WriteLine("Id inválido! Operação cancelada.");
                        break;
                    }
                    Livro.ExcluirLivro(idExc);
                    break;
                case 6:
                    // Relatório: quantidade total de livros
                    Livro.QuantidadeTotalLivros();
                    break;
                case 7:
                    // Relatório: listar livros publicados após ano informado
                    Console.Write("Digite o ano: ");
                    if (!int.TryParse(Console.ReadLine(), out int anoRel) || anoRel <= 0)
                    {
                        Console.WriteLine("Ano inválido! Operação cancelada.");
                        break;
                    }
                    Livro.ListarLivrosAposAno(anoRel);
                    break;
                case 0:
                    Console.WriteLine("Encerrando o sistema...");
                    break;
                default:
                    Console.WriteLine("Opção inválida!");
                    break;
            }
        }
    }
}
