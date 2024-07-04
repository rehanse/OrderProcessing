using OrderProcessing.DataAccess.Domain.Features.Orders;
using OrderProcessing.DataAccess.Domain.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderProcessing.DataAccess.Contracts.Persistence
{
    public interface IOrdersRepository
    {
        Task<List<OrdersDto>> OrderList();
        Task<OrdersDto> GetOrderByOrderId(int orderId);
        Task<ResponseStatus> CreateOrder(OrdersDto ordersDto);
    }
}
