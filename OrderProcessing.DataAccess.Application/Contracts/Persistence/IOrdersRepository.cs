using OrderProcessing.DataAccess.Application.Features.Orders.Queries.GetOrders;
using OrderProcessing.DataAccess.Domain.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderProcessing.DataAccess.Application.Contracts.Persistence
{
    public interface IOrdersRepository
    {
        Task<List<OrdersDto>> OrderList();
        Task<OrdersDto> GetOrderByOrderId(string orderId);
        Task<ResponseStatus> CreateOrder(OrdersDto ordersDto);
    }
}
