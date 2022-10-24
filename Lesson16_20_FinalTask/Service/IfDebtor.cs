using Lesson16_20_FinalTask.Models;
using Lesson16_20_FinalTask.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson16_20_FinalTask.Service
{
    public class IfDebtor
    {
        //Metodas patikrinti ar klientas yra skolininkas ir išvesti į konsolę
        public string CheckIfDebtor(ClientRepository _clientRepository, List<Order> listOfOrders, int clientID)
        {
            string answer = "";
            var client = _clientRepository.Retrieve(clientID);
            foreach(var order in listOfOrders)
            {
                if(client.ClientID == order.CustomerID)
                {
                    int checkTheDate = 0;
                    checkTheDate = (DateTime.Today - order.DateOFOrder).Days;
                    if (checkTheDate > client.PossiblDelay)
                    {
                        answer = answer + $"Klientas {client.ClientName} vėluoja sumokėti užsakymą ID:{order.OrderID}\n" +
                            $"Užsakymo sukūrimo data {order.DateOFOrder}\n" +
                            $"Atidėjimas: {client.PossiblDelay}d. Nuo užsakymo praėjo: {checkTheDate}d. Pradelsta {checkTheDate-client.PossiblDelay}d.\n";
                    }
                    else
                    {
                        answer = answer + $"Klientas {client.ClientName} nevėluoja sumokėti užsakymo ID:{order.OrderID}\n" +
                            $"Užsakymo sukūrimo data {order.DateOFOrder}\n" +
                            $"Atidėjimas: {client.PossiblDelay}d. Nuo užsakymo praėjo: {checkTheDate}d. Liko dienų sumokėti {client.PossiblDelay-checkTheDate}d.\n";
                    }
                }
            }
            if(answer == "")
            {
                answer = "Klientas šiuo metu neturi jokių aktyvių užsakymų";
            }
            return answer;
        }
        //Metodas patikrinti ar klientas yra skolininkas išvesti true or false
        public bool CheckIfDebtorBool(ClientRepository _clientRepository, List<Order> listOfOrders, int clientID)
        {
            bool answer;
            var client = _clientRepository.Retrieve(clientID);
            int count = 0;
            foreach (var order in listOfOrders)
            {
                if (!order.IfPaid) 
                {
                    if (client.ClientID == order.CustomerID)
                    {
                        int checkTheDate = 0;
                        checkTheDate = (DateTime.Today - order.DateOFOrder).Days;
                        if (checkTheDate > client.PossiblDelay)
                        {
                            count = count + 1;
                        }
                    }
                }   
            }
            if (count > 0)
            {
                answer = true;
            }
            else
            {
                answer = false;
            }
            return answer;
        }
    }
}
