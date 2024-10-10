using DataAccessLayer;
using DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business_Layer.Order
{
    public class Order
    {
        public enum enMode { AddNew = 0, Update = 1 };
        public enMode Mode = enMode.AddNew;

        public int? OrderID { get; set; }
        public int? CustomerID { get; set; }
        public DateTime OrderDate { get; set; }
        public decimal TotalAmount { get; set; }
        public string PaymentStatus { get; set; }
        public string DeliveryStatus { get; set; }

        public Order(OrderDTO orderDto, enMode mode = enMode.AddNew)
        {
            OrderID = orderDto.OrderID;
            CustomerID = orderDto.CustomerID;
            OrderDate = orderDto.OrderDate;
            TotalAmount = orderDto.TotalAmount;
            PaymentStatus = orderDto.PaymentStatus;
            DeliveryStatus = orderDto.DeliveryStatus;

            Mode = mode;
        }

        // Convert to DTO
        public OrderDTO ToOrderDto() =>
            new OrderDTO(OrderID, CustomerID, OrderDate, TotalAmount, PaymentStatus, DeliveryStatus);

        private bool _Add()
        {
            OrderID = OrderData.Add(new OrderCreateDTO(CustomerID, TotalAmount, PaymentStatus, DeliveryStatus));
            return OrderID.HasValue;
        }

        private bool _Update()
        {
            return OrderData.UpdateOrder(new OrderUpdateDTO(OrderID, CustomerID, TotalAmount, PaymentStatus, DeliveryStatus));
        }

        public bool Save()
        {
            switch (Mode)
            {
                case enMode.AddNew:
                    if (_Add())
                    {
                        Mode = enMode.Update;
                        return true;
                    }
                    return false;

                case enMode.Update:
                    return _Update();
            }

            return false;
        }

        public static OrderDTO? FindOrderById(int orderId)
        {
            return OrderData.GetOrderById(orderId);
        }

        public static List<OrderDTO> FindOrdersByCustomerId(int customerID)
        {
            return OrderData.GetOrdersByCustomerId(customerID);
        }

        public static List<OrderDTO> All()
            => OrderData.GetAllOrders();

        public static bool Delete(int orderID)
            => OrderData.DeleteOrder(orderID);


    }
}

