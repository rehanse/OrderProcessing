using Moq;
using OrderProcessing.API.Controllers;
using OrderProcessing.DataAccess.Contracts.Persistence;
using OrderProcessing.DataAccess.Domain.Features.Orders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderProcessXunitTest.Controller
{
    public class OrderProcessControllerUnitTest
    {
        private Mock<IOrdersRepository> _orderRepository;

        public OrderProcessControllerUnitTest()
        {
            this._orderRepository = new Mock<IOrdersRepository>();
        }
        [Fact]
        public void GetOrderList_onSuccess()
        {
            //Arrange
            var orderList = GetOrderList().Result;
            _orderRepository.Setup(x => x.OrderList()).ReturnsAsync(orderList);
            var orderController = new OrdersController(_orderRepository.Object);

            //act
            var orderResult = orderController.GetOrders();

            //assert
            Assert.NotNull(orderResult);
            Assert.Equal(orderList.Count(), orderResult.Result.Count());
            Assert.Equal(GetOrderList().ToString(), orderResult.ToString());
            Assert.True(orderList.Equals(orderResult.Result));
        }

        private async Task<List<OrdersDto>> GetOrderList()
        {
            List<OrdersDto> carList = new List<OrdersDto>
            {
                new OrdersDto
                {
                 orderId = 1,
                orderStatus = "Created",
                productName = "VIVO",
                productCode = "Bh233",
                productDescription = "Test",
                productPrice = 23123,
                customerName = "Rahul",
                customerMobileNo = "9852571771",
                customerAddress = "enayat",
                }


            };

            return carList;

        }

    }
}
