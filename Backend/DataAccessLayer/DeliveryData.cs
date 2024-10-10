using CakeDeliveryDTO.DeliveryDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class DeliveryData
    {
        /// <summary>
        /// Adds a new Delivery to the database.
        /// </summary>
        /// <param name="delivery">DeliveryCreateDTO with delivery data.</param>
        /// <returns>The new DeliveryID if successful, otherwise null.</returns>
        public static int? Add(DeliveryCreateDTO delivery)
        {
            return DataAccessHelper.Add(
                "sp_AddDelivery",  
                "NewDeliveryID",   
                delivery           
            );
        }

        /// <summary>
        /// Retrieves a delivery by its ID.
        /// </summary>
        /// <param name="deliveryId">The ID of the delivery to find.</param>
        /// <returns>DeliveryDTO if found, otherwise null.</returns>
        public static DeliveryDTO? GetDeliveryById(int? deliveryId)
        {
            return DataAccessHelper.GetByParameter<DeliveryDTO>(
                "sp_GetDeliveryById",
                "DeliveryID",
                deliveryId,
                clsMappings.MapDeliveryDTOFromReader
            );
        }

      

        /// <summary>
        /// Updates an existing delivery in the database.
        /// </summary>
        /// <param name="deliveryToUpdate">DeliveryUpdateDTO with updated delivery data.</param>
        /// <returns>True if successful, otherwise false.</returns>
        public static bool UpdateDelivery(DeliveryDTO deliveryToUpdate)
        {
            return DataAccessHelper.Update(
                "sp_UpdateDelivery",  // Stored procedure for updating a delivery
                deliveryToUpdate      // DTO containing updated data
            );
        }

     
        /// <summary>
        /// Deletes a delivery by its ID.
        /// </summary>
        /// <param name="deliveryId">The ID of the delivery to delete.</param>
        /// <returns>True if successful, otherwise false.</returns>
        public static bool DeleteDelivery(int? deliveryId)
        {
            return DataAccessHelper.Delete(
                "sp_DeleteDelivery",  // Stored procedure for deleting a delivery
                "DeliveryID",         // Parameter name
                deliveryId            // DeliveryID to delete
            );
        }

       
        /// <summary>
        /// Retrieves all deliveries from the database.
        /// </summary>
        /// <returns>A list of DeliveryDTO objects.</returns>
        public static List<DeliveryDTO> GetAllDeliveries()
        {
            return DataAccessHelper.GetAll(
                "sp_GetAllDeliveries",  // Stored procedure name to get all deliveries
                clsMappings.MapDeliveryDTOFromReader
            );
        }
    }
}
