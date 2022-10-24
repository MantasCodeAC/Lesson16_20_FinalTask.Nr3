using Lesson16_20_FinalTask.Repositories;
using Lesson16_20_FinalTask.Service;

namespace Lesson16_20_UnitTests
{
    [TestClass]
    public class IfDebtorTests
    {
        [TestMethod]
        public void CheckIfDebtorBool_ReturnTrue()
        {
            //Arrange
            var ifDebtorCheck = new IfDebtor();
            OrderRepository orderRepository = new OrderRepository();
            ClientRepository clientRepository = new ClientRepository();
            var orders = orderRepository.Retrieve();
            //Act
            var debtor = ifDebtorCheck.CheckIfDebtorBool(clientRepository, orders, 0);
            //Assert
            Assert.IsTrue(debtor);
        }
    }
}
