using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs
{
    public class OrderDTO
    {
        public OrderDTO(int? orderId, int? customerId, DateTime orderDate, decimal totalAmount, string paymentStatus, string deliveryStatus)
        {
            this.OrderID = orderId;
            this.CustomerID = customerId;
            this.OrderDate = orderDate;
            this.TotalAmount = totalAmount;
            this.PaymentStatus = paymentStatus;
            this.DeliveryStatus = deliveryStatus;
        }

        public int? OrderID { get; set; }
        public int? CustomerID { get; set; }
        public DateTime OrderDate { get; set; }
        public decimal TotalAmount { get; set; }
        public string PaymentStatus { get; set; }
        public string DeliveryStatus { get; set; }
    }

}
