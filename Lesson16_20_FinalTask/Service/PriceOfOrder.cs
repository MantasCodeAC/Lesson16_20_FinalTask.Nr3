using Lesson16_20_FinalTask.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson16_20_FinalTask.Service
{
    public class PriceOfOrder
    {
        public double SumOfProducts(Order order)
        {
            double sumOfProducts = 0;
            foreach(var product in order.ListOfProducts)
            {
                sumOfProducts = sumOfProducts + product.ProductPrice;
            }
            return sumOfProducts;
        }
    }
}
