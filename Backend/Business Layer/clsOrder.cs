using DataAccessLayer;
using DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
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
            new OrderDTO(this.OrderID, this.CustomerID, this.OrderDate, this.TotalAmount, this.PaymentStatus, this.DeliveryStatus);

        private bool _Add()
        {
            OrderID = clsOrderData.Add(new OrderCreateDTO(this.CustomerID, this.TotalAmount, this.PaymentStatus, this.DeliveryStatus));
            return (OrderID.HasValue);
        }

        private bool _Update()
        {
            return clsOrderData.UpdateOrder(new OrderUpdateDTO(this.OrderID, this.CustomerID,  this.TotalAmount, this.PaymentStatus, this.DeliveryStatus));
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

        public static OrderDTO? FindOrderById(int? orderId)
        {
            return clsOrderData.GetOrderById(orderId);
        }

        public static List<OrderDTO> All()
            => clsOrderData.GetAllOrders();

        public static bool Delete(int? orderID)
            => clsOrderData.DeleteOrder(orderID);

        public static bool Exists(object data, enFindBy findBy)
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
                        var orders = clsOrderData.GetOrdersByCustomerId(customerId);
                        return orders.Any();
                    }
                    break;
            }

            return false;
        }

            => clsOrderData.GetOrdersByCustomerId(customerId);
    }
}

