using Lesson16_20_FinalTask.Repositories;
using Lesson16_20_FinalTask.Service;

namespace Lesson16_20_UnitTests
{
    [TestClass]
    public class PriceOfOrderTests
    {
        [TestMethod]
        public void SumOfProducts_ReturnOrderPrice()
        {
            //Arrange
            var priceCalculator = new PriceOfOrder();
            OrderRepository orderRepository = new OrderRepository();
            var order = orderRepository.Retrieve(9);
            //Act
            var priceOfOrder = priceCalculator.SumOfProducts(order);
            //Assert
            Assert.AreEqual(priceOfOrder, 298.02);
        }
    }
}