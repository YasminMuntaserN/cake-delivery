using CakeDeliveryDTO;
using CakeDeliveryDTO.CakeDTOs;
using CakeDeliveryDTO.CustomerDTOs;
using CakeDeliveryDTO.DeliveryDTO;
using CakeDeliveryDTO.FeedbackDTOs;
using CakeDeliveryDTO.SalesDTOs;
using DTOs;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class Mappings
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
                FullName: $"{reader["FirstName"]?.ToString()}{reader["LastName"]?.ToString()}",
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

        public static PaymentDTO MapPaymentDTOFromReader(IDataReader reader)
        {
            return new PaymentDTO(
                PaymentID: (int)reader["PaymentID"],
                OrderID: (int)reader["OrderID"],
                PaymentMethod: reader["PaymentMethod"].ToString() ?? string.Empty,
                PaymentDate: (DateTime)reader["PaymentDate"],
                AmountPaid: (decimal)reader["AmountPaid"],
                PaymentStatus: reader["PaymentStatus"].ToString() ?? string.Empty
            );
        }

        public static OrderItemDTO MapOrderItemDTOFromReader(IDataReader reader)
        {
            return new OrderItemDTO
            (
                OrderItemID: (int)reader["OrderItemID"],
                OrderID: (int)reader["OrderID"],
                CakeID: (int)reader["CakeID"],
                SizeID: (int)reader["SizeID"],
                Quantity: (int)reader["Quantity"],
                PricePerItem: (decimal)reader["PricePerItem"]
            );
        }

        public static CategoryDTO MapCategoryDTOFromReader(IDataReader reader)
        {
            return new CategoryDTO(
                CategoryID: (int)reader["CategoryID"],
                CategoryName: reader["CategoryName"].ToString() ?? string.Empty,
                CategoryImageUrl: reader["CategoryImageURL"].ToString() ?? string.Empty
            );
        }

        public static FeedbackDto MapFeedbackDTOFromReader(IDataReader reader)
        {
            return new FeedbackDto(
                FeedbackID: (int)reader["FeedbackID"],
                CustomerID: (int)reader["CustomerID"],
                Feedback: reader["Feedback"].ToString() ?? string.Empty,
                FeedbackDate: (DateTime)reader["FeedbackDate"],
                Rating: (int)reader["Rating"]
            );
        }


        public static FeedbackWithCustomerName MapFeedbackWithCustomerNameDTOFromReader(IDataReader reader)
        {
            return new FeedbackWithCustomerName(
                FeedbackID: (int)reader["FeedbackID"],
                CustomerName: reader["CustomerName"].ToString() ?? string.Empty,
                Feedback: reader["Feedback"].ToString() ?? string.Empty,
                FeedbackDate: (DateTime)reader["FeedbackDate"],
                Rating: (int)reader["Rating"]
            );
        }

        public static SalesDTO MapSalesWithDTOFromReader( IDataReader reader)
        {
            return new SalesDTO(
                Sales: (decimal)reader["TotalSales"],
                Day: reader["DayOfWeek"].ToString() ?? string.Empty
                );
        }
    }
}
