using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson16_20_FinalTask.Models
{
    public class Client
    {
        public int ClientID { get; set; }
        public string ClientName { get; set; }
        public int PossiblDelay { get; set; }  //For how many days payment delay is possible
        public Client(int clientID, string clientName, int possibleDelay)
        {
            ClientID = clientID; 
            ClientName = clientName; 
            PossiblDelay = possibleDelay;            
        }
    }
}
