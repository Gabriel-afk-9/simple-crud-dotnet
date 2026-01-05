using System;
using Models;
using Repository;

namespace Views
{
    public static class ProductView
    {
        public static void Register()
        {
            Console.Clear();
            Console.WriteLine("--- NOVO PRODUTO ---");

            Console.Write("Nome: ");
            string name = Console.ReadLine();

            Console.Write("Preço: ");
            if(!decimal.TryParse(Console.ReadLine(), out decimal price)) price = 0;

            var p = new Product {Name = name, Price = price};
            ProductRepository.ToAdd(p);

            Console.WriteLine("Sucesso!");
            Pause();
        }

        public static void List()
        {
            Console.Clear();
            Console.WriteLine("--- LISTAR ---");

            var list = ProductRepository.ListAll();

            if(list.Count == 0)
            {
                Console.WriteLine("Vazio.");
            }
            else
            {
                foreach (var item in list)
                {
                    Console.Write($"ID: {item.Id} | {item.Name} | {item.Price:C}");
                }
            }
            Pause();
        }

        public static void Edit()
        {
            Console.Clear();
            Console.Write("ID para editar: ");
            if (int.TryParse(Console.ReadLine(), out int id))
            {
                var product = ProductRepository.SearchForId(id);
                if (product != null)
                {
                    Console.Write($"Novo Nome ({product.Name}): ");
                    string newName = Console.ReadLine();
                    if (!string.IsNullOrEmpty(newName)) product.Name = newName;

                    Console.Write($"Novo Preço ({product.Price}): ");
                    if (decimal.TryParse(Console.ReadLine(), out decimal newPrice)) product.Price = newPrice;
                    
                    Console.WriteLine("Atualizado!");
                }
                else
                {
                    Console.WriteLine("Não encontrado.");
                }
            }
            else
            {
                Console.WriteLine("ID inválido");
            }
            Pause();
        }
        
        public static void Remove()
        {
            Console.Clear();
            Console.Write("ID para remover: ");
            if (int.TryParse(Console.ReadLine(), out int id))
            {
                var product = ProductRepository.SearchForId(id);
                if (product != null)
                {
                    ProductRepository.Clear(product);
                    Console.WriteLine("Removido!");
                } 
                else
                {
                    Console.WriteLine("Não encontrado");
                }
            }
            Pause();

        }

        public static void Pause()
        {
            Console.WriteLine("\nPressione qualquer tecla para voltar...");
            Console.ReadLine();
        }

    }
}