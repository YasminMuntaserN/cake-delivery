using CakeDeliveryDTO.CakeDTOs;
using CakeDeliveryDTO.CustomerDTOs;
using CakeDeliveryDTO.DeliveryDTO;
using DTOs;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class clsMappings
    {
        public static CakeDTO MapCakeDTOFromReader(IDataReader reader)
        {
            return new CakeDTO(
                CakeID: (int)reader["CakeID"],
                CakeName: reader["CakeName"].ToString() ?? string.Empty,
                Description: reader["Description"].ToString() ?? string.Empty,
                Price: (decimal)reader["Price"],
                StockQuantity: (int)reader["StockQuantity"],
                CategoryID: (int)reader["CategoryID"],
                ImageUrl: reader["ImageUrl"].ToString() ?? string.Empty
            );
        }

        public static CustomerDTO MapCustomerDTOFromReader(IDataReader reader)
        {
            return new CustomerDTO(
                CustomerID: (int)reader["CustomerID"],
                FirstName: reader["FirstName"]?.ToString() ?? string.Empty,
                LastName: reader["LastName"]?.ToString() ?? string.Empty,
                FullName: string.Concat(reader["FirstName"]?.ToString(), " ", reader["LastName"]?.ToString()),
                Email: reader["Email"]?.ToString() ?? string.Empty,
                PhoneNumber: reader["PhoneNumber"]?.ToString() ?? string.Empty,
                Address: reader["Address"]?.ToString() ?? string.Empty,
                City: reader["City"]?.ToString() ?? string.Empty,
                PostalCode: reader["PostalCode"]?.ToString() ?? string.Empty,
                Country: reader["Country"]?.ToString() ?? string.Empty
            );
        }

        public static OrderDTO MapOrderDTOFromReader(IDataReader reader)
        {
            return new OrderDTO(
                OrderID: (int)reader["OrderID"],
                CustomerID: (int)reader["CustomerID"],
                OrderDate: (DateTime)reader["OrderDate"],
                TotalAmount: (decimal)reader["TotalAmount"],
                PaymentStatus: reader["PaymentStatus"].ToString() ?? string.Empty,
                DeliveryStatus: reader["DeliveryStatus"].ToString() ?? string.Empty
            );
        }

        public static DeliveryDTO MapDeliveryDTOFromReader(IDataReader reader)
        {
            return new DeliveryDTO(
                DeliveryID: (int)reader["DeliveryID"],
                OrderID: (int)reader["OrderID"],
                DeliveryAddress: reader["DeliveryAddress"].ToString() ?? string.Empty,
                DeliveryCity: reader["DeliveryCity"].ToString() ?? string.Empty,
                DeliveryPostalCode: reader["DeliveryPostalCode"].ToString() ?? string.Empty,
                DeliveryCountry: reader["DeliveryCountry"].ToString() ?? string.Empty,
                DeliveryDate: (DateTime)reader["DeliveryDate"],
                DeliveryStatus: reader["DeliveryStatus"].ToString() ?? string.Empty
            );
        }

    }
}
