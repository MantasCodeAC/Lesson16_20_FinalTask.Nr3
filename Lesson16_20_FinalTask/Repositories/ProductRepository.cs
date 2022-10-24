using Lesson16_20_FinalTask.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson16_20_FinalTask.Repositories
{
    public class ProductRepository
    {
        private List<Product> Products = new List<Product>();
        public ProductRepository()
        {
            var text = System.IO.File.ReadAllLines(@"C:\Users\Vartotojas\Desktop\CodeAcademy\2-a paskaita\Lesson16_20_FinalTask\Lesson16_20_FinalTask\bin\Debug\net6.0\ProductRepository.txt")
                .Select(x => x.Split(new[] { ';' }, StringSplitOptions.RemoveEmptyEntries))
                .Where(x => x.Length > 1)
                .Select(x => new { ID = x[0].Trim(), Name = x[1].Trim(), Price = x[2].Trim() })
                .ToList();
            foreach (var element in text)
            {
                Products.Add(new Product(Int32.Parse(element.ID), element.Name, Convert.ToDouble(element.Price)));
            }           
        }
        public Product Retrieve(int productID)
        {
            var talpykla = Products[0];
            for (int i = 0; i < Products.Count; i++)
            {
                if (Products[i].ProductID == productID)
                {
                    talpykla = Products[i];
                }
            }
            return talpykla;
        }
        public List<Product> Retrieve()
        {
            return Products;
        }
    }
}
