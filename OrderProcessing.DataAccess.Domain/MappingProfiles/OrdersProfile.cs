using AutoMapper;
using OrderProcessing.DataAccess.Domain;
using OrderProcessing.DataAccess.Domain.Features.Orders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderProcessing.DataAccess.MappingProfiles
{
    public class OrdersProfile: Profile
    {
        public OrdersProfile()
        {
            CreateMap<OrdersDto, TORDERS>();
            CreateMap<TORDERS, OrdersDto>();
        }
    }
}
