using Models;
using System.Linq;
using System.Collections.Generic;

namespace Repository
{
    public class ProductRepository
    {
        private static List<Product> products = new List<Product>();
        private static int countId = 1;

        public static void ToAdd(Product product)
        {
            product.Id = countId;
            products.Add(product);
            countId++;
        }

        public static List<Product> ListAll()
        {
            return products;
        }

        public static Product SearchForId(int id)
        {
            return products.Find(p => p.Id == id);
        }

        public static void Clear(Product product)
        {
            products.Remove(product);
        }
    }
}
