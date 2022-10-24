using Lesson16_20_FinalTask.Models;
using Lesson16_20_FinalTask.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson16_20_FinalTask.Service
{
    internal class ReportGenerator
    {
        public string ReportAllClients( ClientRepository _clientRepository, OrderRepository _orderRepository)
        {
            HowManyOrderOnClient howManyOrderOnClient = new HowManyOrderOnClient();
            IfDebtor ifDebtor = new IfDebtor();
            String answer = "***** List Of All Clients *****/\n";
            answer += String.Format("{0, -12} {1,-13} {2, -16} {3, -17} {4, -25} \n",
                "ClientID", "Client Name", "Possible Delay", "Active Orders", "Is the client delayer?");                
            foreach(var client in _clientRepository.Retrieve())
            {
                answer += String.Format("{0, -14} {1,-16} {2, -11} {3, -17} {4, -25} \n",
                    $"  {client.ClientID}", $"{client.ClientName}", $"{client.PossiblDelay}",
                    $"{howManyOrderOnClient.CheckHowManyOrders(_orderRepository.Retrieve(),client.ClientID).Item1}" +
                    $"{howManyOrderOnClient.CheckHowManyOrders(_orderRepository.Retrieve(), client.ClientID).Item2}",
                    $"{ifDebtor.CheckIfDebtorBool(_clientRepository, _orderRepository.Retrieve(), client.ClientID)}");
            }
            return answer;
        }
        public string ReportUnpaidOrders(ClientRepository _clientRepository, OrderRepository _orderRepository)
        {
            PriceOfOrder priceOfOrder = new PriceOfOrder();
            String answer = "***** List Of Unpaid Orders *****/\n";           
            foreach (var order in _orderRepository.Retrieve())
            {
                if (!order.IfPaid)
                {
                    answer += "___________________________________________________________________________________________\n";
                    answer += String.Format("{0, -9} {1,1} {2,-13} {3,1} {4, -14} {5,1} {6, -13} {7,1} {8, -11} {9,1} {10,-14} {11,1} \n",
                        "| OrderID","|", "Date Of Order", "|", "Customer Name", "|", " Days to Pay", "|", " Products", "|", "Price Of Order", "|");
                    answer += String.Format("{0, -9} {1,1} {2,-13} {3,1} {4, -14} {5,1} {6, -13} {7,1} {8, -11} {9,1} {10,-14} {11,1}\n",
                        $"|    {order.OrderID}", "|", $" {order.DateOFOrder.ToShortDateString()}", "|", $"  {_clientRepository.Retrieve(order.CustomerID).ClientName}", "|",
                        $"     {_clientRepository.Retrieve(order.CustomerID).PossiblDelay - (DateTime.Today - order.DateOFOrder).Days}", "|",
                        $"     {order.NumberOfProducts}", "|", $"     {Math.Round(priceOfOrder.SumOfProducts(order),2)}", "|");
                    answer += $"____________________________________________" +
                        $"\nThis Order (ID {order.OrderID}) contains these products: \n";
                    answer += String.Format("{0, -12} {1,-20} {2, -16} \n",
                        "Product ID", "Product Name", "Product Price");
                    foreach(var product in order.ListOfProducts)
                    {
                        answer += String.Format("{0, -12} {1,-20} {2, -6} {3,-10} \n",
                            $"{product.ProductID}", $"{product.ProductName}", $"{product.ProductPrice}", "Eur.");
                    }
                    answer += "END OF ORDER--------------------------------\n\n\n";
                }
            }
            return answer;
        }
    }
}
