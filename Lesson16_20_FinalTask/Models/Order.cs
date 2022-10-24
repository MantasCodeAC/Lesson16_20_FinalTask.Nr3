using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson16_20_FinalTask.Models
{
    public class Order
    {
        public int OrderID { get; set; }
        public int NumberOfProducts { get; set; }
        public List<Product> ListOfProducts { get; set; }
        public int CustomerID { get; set; }
        public bool IfPaid { get; set; }
        public DateTime DateOFOrder { get; set; }
        public Order(int orderID, int numberOfProducts, List<Product> listOfProducts, int customerID, bool ifPaid, DateTime dateOFOrder)
        {
            OrderID = orderID;
            NumberOfProducts = numberOfProducts;
            ListOfProducts = listOfProducts;
            CustomerID = customerID;
            IfPaid = ifPaid;
            DateOFOrder = dateOFOrder;
        }
    }
}
