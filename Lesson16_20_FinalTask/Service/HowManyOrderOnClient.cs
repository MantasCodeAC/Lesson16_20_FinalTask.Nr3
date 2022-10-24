using Lesson16_20_FinalTask.Models;
using Lesson16_20_FinalTask.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson16_20_FinalTask.Service
{
    internal class HowManyOrderOnClient
    {       
        public Tuple<int, string> CheckHowManyOrders(List<Order> listOfOrders, int clientID)
        {
            string answer = "";
            int numberOfOrders = 0;
            foreach(var order in listOfOrders)
            {
                if (order.CustomerID == clientID)
                {
                    numberOfOrders = numberOfOrders + 1;
                    answer += $"(ID{order.OrderID})";
                }
            }
            return Tuple.Create(numberOfOrders, answer);
        }
    }
}
