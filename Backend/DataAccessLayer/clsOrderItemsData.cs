using CakeDeliveryDTO;
using DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class clsOrderItemData
    {
        /// <summary>
        /// Adds a new OrderItem to the database.
        /// </summary>
        /// <param name="orderItem">OrderItemCreateDTO with OrderItem data.</param>
        /// <returns>The new OrderItemID if successful, otherwise null.</returns>
        public static int? Add(OrderItemCreateDTO orderItem)
        {
            return DataAccessHelper.Add(
                "sp_AddOrderItem",
                "NewOrderItemID",
                orderItem
            );
        }

     
        /// <summary>
        /// Retrieves an OrderItem by its ID.
        /// </summary>
        /// <param name="orderItemId">The ID of the OrderItem to find.</param>
        /// <returns>OrderItemDTO if found, otherwise null.</returns>
        public static OrderItemDTO? GetOrderItemById(int? orderItemId)
        {
            return DataAccessHelper.GetByParameter<OrderItemDTO>(
                "sp_GetOrderItemById",
                "OrderItemID",
                orderItemId,
                clsMappings.MapOrderItemDTOFromReader
            );
        }

        /// <summary>
        /// Updates an existing OrderItem in the database.
        /// </summary>
        /// <param name="orderItemToUpdate">OrderItemDTO with updated OrderItem data.</param>
        /// <returns>True if successful, otherwise false.</returns>
        public static bool UpdateOrderItem(OrderItemDTO orderItemToUpdate)
        {
            return DataAccessHelper.Update(
                "sp_UpdateOrderItem",
                orderItemToUpdate
            );
        }


        /// <summary>
        /// Deletes an OrderItem by its ID.
        /// </summary>
        /// <param name="orderItemId">The ID of the OrderItem to delete.</param>
        /// <returns>True if successful, otherwise false.</returns>
        public static bool DeleteOrderItem(int? orderItemId)
        {
            return DataAccessHelper.Delete(
                "sp_DeleteOrderItem",
                "OrderItemID",
                orderItemId
            );
        }

     
        /// <summary>
        /// Retrieves all OrderItems for a specific Order.
        /// </summary>
        /// <param name="orderId">The ID of the Order to filter OrderItems.</param>
        /// <returns>A list of OrderItemDTO objects if found, otherwise an empty list.</returns>
        public static List<OrderItemDTO> GetOrderItemsByOrderId(int orderId)
        {
            return DataAccessHelper.GetAll(
                "sp_GetOrderItemsByOrderId",
                "OrderID",
                orderId,
                clsMappings.MapOrderItemDTOFromReader
            );
        }

      
        /// <summary>
        /// Retrieves all OrderItems for a specific Cake.
        /// </summary>
        /// <param name="cakeId">The ID of the Cake to filter OrderItems.</param>
        /// <returns>A list of OrderItemDTO objects if found, otherwise an empty list.</returns>
        public static List<OrderItemDTO> GetOrderItemsByCakeId(int cakeId)
        {
            return DataAccessHelper.GetAll(
                "sp_GetOrderItemsByCakeId",
                "CakeID",
                cakeId,
                clsMappings.MapOrderItemDTOFromReader
            );
        }

        /// <summary>
        /// Retrieves all OrderItems from the database.
        /// </summary>
        /// <returns>A list of OrderItemDTO objects.</returns>
        public static List<OrderItemDTO> GetAllOrderItems()
        {
            return DataAccessHelper.GetAll(
                "sp_GetAllOrderItems",  
                clsMappings.MapOrderItemDTOFromReader
            );
        }
    }

}
