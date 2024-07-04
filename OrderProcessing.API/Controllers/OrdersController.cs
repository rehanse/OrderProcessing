using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OrderProcess.DataAccess.Persistence.Repositories;
using OrderProcessing.DataAccess.Contracts.Persistence;
using OrderProcessing.DataAccess.Domain.Features.Orders;
using OrderProcessing.DataAccess.Domain.Identity;


namespace OrderProcessing.API.Controllers
{
    [Authorize(Roles = UserRoles.Admin)]
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private IOrdersRepository _orderRepository;

        public OrdersController(IOrdersRepository ordersRepository)
        {
            this._orderRepository = ordersRepository;
        }
        [HttpPost("CreateOrder")]
        public async Task<ActionResult> CreateOrder([FromForm] OrdersDto orders)
        {
            var responseStatus = await _orderRepository.CreateOrder(orders);
            return Ok(responseStatus);

        }

        [HttpGet("GetOrders")]
        public async Task<List<OrdersDto>> GetOrders()
        {
            var orders = await _orderRepository.OrderList();
            return orders;

        }

        [HttpGet("GetOrderById")]
        public async Task<ActionResult> GetOrderById(int orderId)
        {
            var GetCarInfo = await _orderRepository.GetOrderByOrderId(orderId);
            return Ok(GetCarInfo);

        }
    }
}
