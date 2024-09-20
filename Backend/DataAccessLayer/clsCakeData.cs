using CakeDeliveryDTO.CakeDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class clsCakeData
    {
        /// <summary>
        /// Adds a new cake to the database.
        /// </summary>
        /// <param name="cake">CakeCreateRequestDTO with cake data.</param>
        /// <returns>The new CakeID if successful, otherwise null.</returns>
        public int? AddCake(CakeCreateRequestDTO cake)
        {
            return DataAccessHelper.Add(
                "sp_AddCake",  // Stored procedure name for inserting a cake
                "CakeID",      // Output parameter
                cake           // Cake data DTO
            );
        }


        /// <summary>
        /// Retrieves a cake by its ID.
        /// </summary>
        /// <param name="cakeId">The ID of the cake to find.</param>
        /// <returns>CakeUpdateFindRequestDTO if found, otherwise null.</returns>
        public CakeUpdateFindRequestDTO? FindCakeById(int cakeId)
        {
            return DataAccessHelper.GetById(
                "sp_GetCakeById",  // Stored procedure name for retrieving cake by ID
                "CakeID",          // Parameter name
                cakeId,            // The CakeID
                reader => new CakeUpdateFindRequestDTO(
                    CakeID: (int)reader["CakeID"],
                    CakeName: reader["CakeName"].ToString(),
                    Description: reader["Description"].ToString(),
                    Price: (decimal)reader["Price"],
                    StockQuantity: (int)reader["StockQuantity"],
                    Category: reader["Category"].ToString(),
                    ImageUrl: reader["ImageUrl"].ToString()
                )
            );
        }


        /// <summary>
        /// Updates an existing cake in the database.
        /// </summary>
        /// <param name="cakeToUpdate">CakeUpdateFindRequestDTO with updated cake data.</param>
        /// <returns>True if successful, otherwise false.</returns>
        public bool UpdateCake(CakeUpdateFindRequestDTO cakeToUpdate)
        {
            return DataAccessHelper.Update(
                "sp_UpdateCake",  // Stored procedure for updating a cake
                cakeToUpdate      // DTO containing updated data
            );
        }


        /// <summary>
        /// Deletes a cake by its ID.
        /// </summary>
        /// <param name="cakeId">The ID of the cake to delete.</param>
        /// <returns>True if successful, otherwise false.</returns>
        public bool DeleteCake(int cakeId)
        {
            return DataAccessHelper.Delete(
                "sp_DeleteCake",  // Stored procedure for deleting a cake
                "CakeID",         // Parameter name
                cakeId            // CakeID to delete
            );
        }


        /// <summary>
        /// Retrieves all cakes from the database.
        /// </summary>
        /// <returns>A list of CakeUpdateFindRequestDTO objects.</returns>
        public List<CakeUpdateFindRequestDTO> GetAllCakes()
        {
            return DataAccessHelper.GetAll(
                "sp_GetAllCakes", // Stored procedure name to get all cakes
                reader => new CakeUpdateFindRequestDTO(
                    CakeID: (int)reader["CakeID"],
                    CakeName: reader["CakeName"].ToString(),
                    Description: reader["Description"].ToString(),
                    Price: (decimal)reader["Price"],
                    StockQuantity: (int)reader["StockQuantity"],
                    Category: reader["Category"].ToString(),
                    ImageUrl: reader["ImageUrl"].ToString()
                )
            );
        }
    }
}