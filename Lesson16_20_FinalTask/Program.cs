using Lesson16_20_FinalTask.Repositories;
using Lesson16_20_FinalTask.Service;
ClientRepository clientRepository = new ClientRepository();
OrderRepository orderRepository = new OrderRepository();
ReportGenerator generator = new ReportGenerator();
var answer2 = generator.ReportUnpaidOrders(clientRepository, orderRepository);
var answer = generator.ReportAllClients(clientRepository, orderRepository);
System.IO.File.WriteAllText("ataskaitaKlientų.txt", answer);
System.IO.File.WriteAllText("ataskaitaUžsakymų.txt", answer2);


