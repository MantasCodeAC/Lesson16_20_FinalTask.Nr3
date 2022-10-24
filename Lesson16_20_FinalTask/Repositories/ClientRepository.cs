using Lesson16_20_FinalTask.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson16_20_FinalTask.Repositories
{
    public class ClientRepository
    {
        private List<Client> Clients = new List<Client>();
        public ClientRepository()
        {
            var text = System.IO.File.ReadAllLines(@"C:\Users\Vartotojas\Desktop\CodeAcademy\2-a paskaita\Lesson16_20_FinalTask\Lesson16_20_FinalTask\bin\Debug\net6.0\ClientRepository.txt")
                .Select(x => x.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries))
                .Where(x => x.Length > 1)
                .Select(x => new { ID = x[0].Trim(), Name = x[1].Trim(), PossibleDelay = x[2].Trim() })
                .ToList();
            foreach (var element in text)
            {
                Clients.Add(new Client(Int32.Parse(element.ID), element.Name, Int32.Parse(element.PossibleDelay)));
            }           
        }
        public Client Retrieve(int clientID)
        {
            var talpykla = Clients[0];
            for (int i = 0; i < Clients.Count; i++)
            {
                if (Clients[i].ClientID == clientID)
                {
                    talpykla = Clients[i];
                }
            }
            return talpykla;
        }
        public List<Client> Retrieve()
        {
            return Clients;
        }
    }
}
