using DTOs;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class clsOrderData
    {
        /// <summary>
        /// Adds a new Order to the database.
        /// </summary>
        /// <param name="order">OrderCreateDTO with order data.</param>
        /// <returns>The new OrderID if successful, otherwise null.</returns>
        public static int? Add(OrderCreateDTO order)
        {
            return DataAccessHelper.Add(
                "sp_AddOrder",   // Stored procedure name for inserting an order
                "NewOrderID",    // Output parameter
                order            // Order data DTO
            );
        }

      
        /// <summary>
        /// Retrieves an order by its ID.
        /// </summary>
        /// <param name="orderId">The ID of the order to find.</param>
        /// <returns>OrderDTO if found, otherwise null.</returns>
        public static OrderDTO? GetOrderById(int? orderId)
        {
            return DataAccessHelper.GetByParameter<OrderDTO>(
                "sp_GetOrderById",
                "OrderID",
                orderId,
                reader => new OrderDTO(
                    OrderID: (int)reader["OrderID"],
                    CustomerID: (int)reader["CustomerID"],
                    OrderDate: (DateTime)reader["OrderDate"],
                    TotalAmount: (decimal)reader["TotalAmount"],
                    PaymentStatus: reader["PaymentStatus"].ToString(),
                    DeliveryStatus: reader["DeliveryStatus"].ToString()
                )
            );
        }

        /// <summary>
        /// Retrieves a list of orders by the customerID.
        /// </summary>
        /// <param name="customerID">The customerID of the orders to find.</param>
        /// <returns>List of OrderDTOs if found, otherwise an empty list.</returns>
        public static List<OrderDTO> GetOrdersByCustomerId(int? customerID)
        {
            if (!customerID.HasValue || customerID <= 0)
            {
                return new List<OrderDTO>(); // Return an empty list if customerID is not valid
            }

            return DataAccessHelper.GetAll<OrderDTO>(
                "sp_GetOrderByCustomerId",
                "CustomerID",
                customerID,
                reader => new OrderDTO(
                    OrderID: (int)reader["OrderID"],
                    CustomerID: (int)reader["CustomerID"],
                    OrderDate: (DateTime)reader["OrderDate"],
                    TotalAmount: (decimal)reader["TotalAmount"],
                    PaymentStatus: reader["PaymentStatus"].ToString(),
                    DeliveryStatus: reader["DeliveryStatus"].ToString()
                )
            );
        }


        /// <summary>
        /// Updates an existing order in the database.
        /// </summary>
        /// <param name="orderToUpdate">OrderDTO with updated order data.</param>
        /// <returns>True if successful, otherwise false.</returns>
        public static bool UpdateOrder(OrderUpdateDTO orderToUpdate)
        {
            return DataAccessHelper.Update(
                "sp_UpdateOrder",  // Stored procedure for updating an order
                orderToUpdate      // DTO containing updated data
            );
        }

     
        /// <summary>
        /// Deletes an order by its ID.
        /// </summary>
        /// <param name="orderId">The ID of the order to delete.</param>
        /// <returns>True if successful, otherwise false.</returns>
        public static bool DeleteOrder(int? orderId)
        {
            return DataAccessHelper.Delete(
                "sp_DeleteOrder",  // Stored procedure for deleting an order
                "OrderID",         // Parameter name
                orderId            // OrderID to delete
            );
        }

       
        /// <summary>
        /// Retrieves all orders from the database.
        /// </summary>
        /// <returns>A list of OrderDTO objects.</returns>
        public static List<OrderDTO> GetAllOrders()
        {
            return DataAccessHelper.GetAll(
                "sp_GetAllOrders", // Stored procedure name to get all orders
                reader => new OrderDTO(
                    OrderID: (int)reader["OrderID"],
                    CustomerID: (int)reader["CustomerID"],
                    OrderDate: (DateTime)reader["OrderDate"],
                    TotalAmount: (decimal)reader["TotalAmount"],
                    PaymentStatus: reader["PaymentStatus"].ToString(),
                    DeliveryStatus: reader["DeliveryStatus"].ToString()
                )
            );
        }
    }
}