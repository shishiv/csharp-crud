using System;
using CSharpCrud.Models;

namespace CSharpCrud
{
    class Program
    {
        static void Main(string[] args)
        {
            int opcao = -1;
            while (opcao != 0)
            {
                // Menu principal
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

                switch (opcao)
                {
                    case 1:
                        Livro.ListarLivros();
                        break;
                    case 2:
                        Console.Write("Digite o título para buscar: ");
                        string tituloBusca = Console.ReadLine() ?? "";
                        Livro.BuscarLivro(tituloBusca);
                        break;
                    case 3:
                        // Cadastro de novo livro com validação de ano
                        Livro novo = new Livro();
                        Console.Write("Título: ");
                        novo.Titulo = Console.ReadLine() ?? "";
                        Console.Write("Autor: ");
                        novo.Autor = Console.ReadLine() ?? "";
                        Console.Write("Editora: ");
                        novo.Editora = Console.ReadLine() ?? "";
                        Console.Write("Ano de publicação: ");
                        string anoStr = Console.ReadLine() ?? "";
                        if (!int.TryParse(anoStr, out int ano) || ano <= 0)
                        {
                            Console.WriteLine("Ano inválido! Operação cancelada.");
                            break;
                        }
                        novo.Ano = ano;
                        Console.Write("ISBN: ");
                        novo.ISBN = Console.ReadLine() ?? "";
                        Console.Write("Gênero: ");
                        novo.Genero = Console.ReadLine() ?? "";
                        Livro.InserirLivro(novo);
                        break;
                    case 4:
                        Console.Write("Digite o id do livro a alterar: ");
                        string idAltStr = Console.ReadLine() ?? "";
                        if (!int.TryParse(idAltStr, out int idAlt) || idAlt <= 0)
                        {
                            Console.WriteLine("Id inválido! Operação cancelada.");
                            break;
                        }
                        Livro.AlterarLivro(idAlt);
                        break;
                    case 5:
                        Console.Write("Digite o id do livro a excluir: ");
                        string idExcStr = Console.ReadLine() ?? "";
                        if (!int.TryParse(idExcStr, out int idExc) || idExc <= 0)
                        {
                            Console.WriteLine("Id inválido! Operação cancelada.");
                            break;
                        }
                        Livro.ExcluirLivro(idExc);
                        break;
                    case 6:
                        Livro.QuantidadeTotalLivros();
                        break;
                    case 7:
                        Console.Write("Digite o ano: ");
                        string anoRelStr = Console.ReadLine() ?? "";
                        if (!int.TryParse(anoRelStr, out int anoRel) || anoRel <= 0)
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
}
