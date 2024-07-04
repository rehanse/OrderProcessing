using AutoMapper;
using Microsoft.EntityFrameworkCore;
using OrderProcess.DataAccess.Persistence.DatabaseContext;
using OrderProcessing.DataAccess.Contracts.Persistence;
using OrderProcessing.DataAccess.Domain;
using OrderProcessing.DataAccess.Domain.Features.Orders;
using OrderProcessing.DataAccess.Domain.Identity;
using OrderProcessing.DataAccess.Domain.OrderProcess;
using OrderProcessing.DataAccess.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace OrderProcess.DataAccess.Persistence.Repositories
{
    public class OrdersRepository:IOrdersRepository
    {
        private readonly OrderProcessDatabaseContext _dbContext;
        private readonly IMapper _mapper;
        private ResponseStatus _responseStatus;
        public OrdersRepository(IMapper mapper, OrderProcessDatabaseContext databaseContext, ResponseStatus responseStatus)
        {
            this._mapper = mapper;
            this._dbContext = databaseContext;
            this._responseStatus = responseStatus;
        }
        /// <summary>
        /// Add the Order details 
        /// </summary>
        /// <param name="orderDTO"></param>
        /// <returns></returns>
        /// <exception cref="NotFoundException"></exception>
        public async Task<ResponseStatus> CreateOrder(OrdersDto ordersDto)
        {
            try
            {
                var order = _mapper.Map<TORDERS>(ordersDto);
                await _dbContext.TORDERs.AddAsync(order);
                await _dbContext.SaveChangesAsync();
                _responseStatus.statusCode = 1;
                _responseStatus.message = "Order has been successfully inserted";
                return _responseStatus;
            }
            catch (Exception ex)
            {
                throw new NotFoundException(nameof(TORDERS), "Data not insert into database", ex.Message);
            }
        }

        public async Task<OrdersDto> GetOrderByOrderId(int orderId)
        {
            var order = await _dbContext.TORDERs.Where(x => x.orderId == orderId).FirstOrDefaultAsync();
            var orderDto = _mapper.Map<OrdersDto>(order);
            if (order == null)
            {
                throw new NotFoundException(nameof(order), "Data not found", "");
            }
            return orderDto;
        }

        public async Task<List<OrdersDto>> OrderList()
        {
            var orderList = (from ord in _dbContext.TORDERs
                            select new OrdersDto
                            {
                                orderId = ord.orderId,
                                orderStatus = ord.orderStatus,
                                productName = ord.productName,
                                productCode = ord.productCode,
                                productDescription = ord.productDescription,
                                productPrice = ord.productPrice,
                                customerName = ord.customerName,
                                customerMobileNo = ord.customerMobileNo,
                                customerAddress = ord.customerAddress,
                            }).AsNoTracking().ToList();
            if (orderList == null)
            {
                throw new NotFoundException(nameof(orderList), "orderList is Empty", "");
            }
            return orderList;
        }
    }
}
