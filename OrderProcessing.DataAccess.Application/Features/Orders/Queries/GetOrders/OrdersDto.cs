using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderProcessing.DataAccess.Application.Features.Orders.Queries.GetOrders
{
    public class OrdersDto
    {
       
        public string? orderId{ get; set; }
        public string? orderStatus { get; set; }
        public string? productName { get; set; }
        public string? productCode { get; set; }
        public string? productDescription { get; set; }
        public string? productPrice { get; set; }
        public string? customerName { get; set; }
        public string? customerMobileNo { get; set; }
        public string? customerAddress { get; set; }



    }
}
