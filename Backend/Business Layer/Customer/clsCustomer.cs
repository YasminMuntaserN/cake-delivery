using CakeDeliveryDTO.CustomerDTOs;
using DataAccessLayer;
using DTOs;
using Microsoft.Extensions.Primitives;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business_Layer.Customer
{
    public class clsCustomer
    {
        public enum enFindBy
        {
            CustomerID,
            Name
        };

        public enum enMode { AddNew = 0, Update = 1 };
        public enMode Mode = enMode.AddNew;

        public int? CustomerID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName => string.Concat(FirstName, " ",LastName);
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string PostalCode { get; set; }
        public string Country { get; set; }
        public DateTime CreatedAt { get; set; }


        public clsCustomer(CustomerDTO customerDto, enMode mode = enMode.AddNew)
        {
            CustomerID = customerDto.CustomerID;
            FirstName = customerDto.FirstName;
            LastName = customerDto.LastName;
            Email = customerDto.Email;
            PhoneNumber = customerDto.PhoneNumber;
            Address = customerDto.Address;
            City = customerDto.City;
            PostalCode = customerDto.PostalCode;
            Country = customerDto.Country;
            CreatedAt = customerDto.CreatedAt;

            Mode = mode;
        }

        // Convert to DTO
        public CustomerDTO TocustomerDto() =>
            new CustomerDTO(CustomerID, FirstName, LastName,FullName, Email, PhoneNumber, Address, City, PostalCode, Country , CreatedAt);

        private bool _Add()
        {
            CustomerID = clsCustomerData.Add(new OrderCreateDTO(CustomerID, TotalAmount, PaymentStatus, DeliveryStatus));
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

        public static customerDto? FindOrderById(int? orderId)
        {
            return clsOrderData.GetOrderById(orderId);
        }

        public static List<customerDto> FindOrdersByCustomerId(int? customerID)
        {
            return clsOrderData.GetOrdersByCustomerId(customerID);
        }

        public static List<customerDto> All()
            => clsOrderData.GetAllOrders();

        public static bool Delete(int? orderID)
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

