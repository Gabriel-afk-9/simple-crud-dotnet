//dotnet run
using System;
using Views;

namespace SimpleCrud
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                DisplayMainMenu();
                string option = Console.ReadLine();

                switch (option) {
                    case "1": ProductView.Register();break;
                    case "2": ProductView.List();break;
                    case "3": ProductView.Edit();break;
                    case "4": ProductView.Remove();break;
                    case "0": Environment.Exit(0);break;
                    default:
                        Console.WriteLine("Opção inválida!");
                        Console.ReadLine();
                        break;
                } 
            }
        }

        static void DisplayMainMenu()
        {
            Console.Clear();
            Console.WriteLine("=== GESTÃO DE PRODUTOS ===");
            Console.WriteLine("1 - Cadastrar Produto");
            Console.WriteLine("2 - Listar Produtos");
            Console.WriteLine("3 - Editar Produto");
            Console.WriteLine("4 - Remover Produto");
            Console.WriteLine("0 - Sair");
            Console.Write("Escolha uma opção: ");
        }
    }
}