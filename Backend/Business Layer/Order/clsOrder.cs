using DataAccessLayer;
using DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business_Layer.Order
{
    public class clsOrder
    {
        public enum enFindBy
        {
            OrderID,
            CustomerID
        };

        public enum enMode { AddNew = 0, Update = 1 };
        public enMode Mode = enMode.AddNew;

        public int? OrderID { get; set; }
        public int? CustomerID { get; set; }
        public DateTime OrderDate { get; set; }
        public decimal TotalAmount { get; set; }
        public string PaymentStatus { get; set; }
        public string DeliveryStatus { get; set; }

        public clsOrder(OrderDTO orderDto, enMode mode = enMode.AddNew)
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
            OrderID = clsOrderData.Add(new OrderCreateDTO(CustomerID, TotalAmount, PaymentStatus, DeliveryStatus));
            return OrderID.HasValue;
        }

        private bool _Update()
        {
            return clsOrderData.UpdateOrder(new OrderUpdateDTO(OrderID, CustomerID, TotalAmount, PaymentStatus, DeliveryStatus));
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
            return clsOrderData.GetOrderById(orderId);
        }

        public static List<OrderDTO> FindOrdersByCustomerId(int customerID)
        {
            return clsOrderData.GetOrdersByCustomerId(customerID);
        }

        public static List<OrderDTO> All()
            => clsOrderData.GetAllOrders();

        public static bool Delete(int orderID)
            => clsOrderData.DeleteOrder(orderID);

        public static bool Exists<T>(T data, enFindBy findBy)
        {
            switch (findBy)
            {
                case enFindBy.OrderID:
                    if (data is int orderId)
                    {
                        var order = clsOrderData.GetOrderById(orderId);
                        return order != null;
                    }
                    break;

                case enFindBy.CustomerID:
                    if (data is int customerId)
                    {
                        var order = clsOrderData.GetOrdersByCustomerId(customerId);
                        return order != null;
                    }
                    break;
            }

            return false;
        }

    }
}

