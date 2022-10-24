using Lesson16_20_FinalTask.Models;
using Lesson16_20_FinalTask.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson16_20_FinalTask.Repositories
{
    public class OrderRepository
    {
        private List<Order> Orders = new List<Order>();
        //Kad nebūtų viskas monotoniška sukūriau užsakymų generatorių,
        //kuriame sugeneruoju užsakymą su jame esančiu produktų sąrašu ir priskiriu užsakymą random klientui.
        //Paskutinį užsakymą sukuriu rankiniu būdu, kad žinočiau jo rezultatą ir galėčiau programos metodams pritaikyti Unit Test
        public OrderRepository()
        {
            Random random = new Random();
            int randomNumberOfProducts = random.Next(1, 10);
            Orders.Add(new Order(0, randomNumberOfProducts, CreateProductList(randomNumberOfProducts), random.Next(1000, 1010), false, RandomDay()));
            randomNumberOfProducts = random.Next(1, 10);
            Orders.Add(new Order(1, randomNumberOfProducts, CreateProductList(randomNumberOfProducts), random.Next(1000, 1010), false, RandomDay()));
            randomNumberOfProducts = random.Next(1, 10);
            Orders.Add(new Order(2, randomNumberOfProducts, CreateProductList(randomNumberOfProducts), random.Next(1000, 1010), false, RandomDay()));
            randomNumberOfProducts = random.Next(1, 10);
            Orders.Add(new Order(3, randomNumberOfProducts, CreateProductList(randomNumberOfProducts), random.Next(1000, 1010), true, RandomDay()));
            randomNumberOfProducts = random.Next(1, 10);
            Orders.Add(new Order(4, randomNumberOfProducts, CreateProductList(randomNumberOfProducts), random.Next(1000, 1010), false, RandomDay()));
            randomNumberOfProducts = random.Next(1, 10);
            Orders.Add(new Order(5, randomNumberOfProducts, CreateProductList(randomNumberOfProducts), random.Next(1000, 1010), false, RandomDay()));
            randomNumberOfProducts = random.Next(1, 10);
            Orders.Add(new Order(6, randomNumberOfProducts, CreateProductList(randomNumberOfProducts), random.Next(1000, 1010), false, RandomDay()));
            randomNumberOfProducts = random.Next(1, 10);
            Orders.Add(new Order(7, randomNumberOfProducts, CreateProductList(randomNumberOfProducts), random.Next(1000, 1010), true, RandomDay()));
            randomNumberOfProducts = random.Next(1, 10);
            Orders.Add(new Order(8, randomNumberOfProducts, CreateProductList(randomNumberOfProducts), random.Next(1000, 1010), false, RandomDay()));           
                List<Product> testList = new List<Product>();
                testList.Add(new Product(100, "Dviračio rėmas", 199.99));
                testList.Add(new Product(101, "Dviračio vairas", 49.99));
                testList.Add(new Product(102, "Dviračio sėdynė", 28.57));
                testList.Add(new Product(103, "Pedalai", 19.47));
                DateTime testDatetime = new DateTime(2022, 10, 1);
            Orders.Add(new Order(9, 4, testList, 1000, false, testDatetime));           
        }
        public Order Retrieve(int orderID)
        {
            var talpykla = Orders[0];
            for (int i = 0; i < Orders.Count; i++)
            {
                if (Orders[i].OrderID == orderID)
                {
                    talpykla = Orders[i];
                }
            }
            return talpykla;
        }
        public List<Order> Retrieve()
        {
            return Orders;
        }
        //vidinis metodas sugeneruoti random dieną
        private DateTime RandomDay()
        {
            Random gen = new Random();
            DateTime start = new DateTime(2022, 8, 1);
            int range = (DateTime.Today - start).Days;
            return start.AddDays(gen.Next(range));
        }
        //vidinis metodas sugeneruoti produktų sąrašą
        private List<Product> CreateProductList(int numberOfProducts)
        {
            ProductRepository productRepository = new ProductRepository();
            List<Product> productsList = new List<Product>();
            while (numberOfProducts > 0)
            {
                Random random = new Random();
                productsList.Add(productRepository.Retrieve(random.Next(100, 110)));
                numberOfProducts--;
            }
            return productsList;
        }
    }
}
