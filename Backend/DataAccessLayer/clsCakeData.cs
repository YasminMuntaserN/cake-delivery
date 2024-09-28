using CakeDeliveryDTO.CakeDTOs;
using Microsoft.Data.SqlClient;
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
        /// Adds a new Cake to the database.
        /// </summary>
        /// <param name="Cake">CakeCreateDto with Cake data.</param>
        /// <returns>The new CakeID if successful, otherwise null.</returns>
        public static int? Add(CakeCreateDto cake)
        {
            return DataAccessHelper.Add(
                "sp_AddCake",  
                "NewCakeID",   
                cake           
            );
        }

       
        /// <summary>
        /// Retrieves a cake by its ID.
        /// </summary>
        /// <param name="cakeId">The ID of the cake to find.</param>
        /// <returns>CakeDTO if found, otherwise null.</returns>
        public static CakeDTO? GetCakeById(int? cakeId)
        {
            return DataAccessHelper.GetByParameter<CakeDTO>(
                "sp_GetCakeById",
                "CakeID",
                cakeId,
                reader => new CakeDTO(
                    CakeID: (int)reader["CakeID"],
                    CakeName: reader["CakeName"].ToString(),
                    Description: reader["Description"].ToString(),
                    Price: (decimal)reader["Price"],
                    StockQuantity: (int)reader["StockQuantity"],
                    CategoryID: (int)reader["CategoryID"],  
                    ImageUrl: reader["ImageUrl"].ToString()
                )
            );
        }

      
        /// <summary>
        /// Retrieves a cake by its name.
        /// </summary>
        /// <param name="cakeName">The name of the cake to find.</param>
        /// <returns>CakeDTO if found, otherwise null.</returns>
        public static CakeDTO? GetCakeByName(string cakeName)
        {
            return DataAccessHelper.GetByParameter<CakeDTO>(
                "sp_GetCakeByName",
                "CakeName",
                cakeName,
                reader => new CakeDTO(
                    CakeID: (int)reader["CakeID"],
                    CakeName: reader["CakeName"].ToString(),
                    Description: reader["Description"].ToString(),
                    Price: (decimal)reader["Price"],
                    StockQuantity: (int)reader["StockQuantity"],
                    CategoryID: (int)reader["CategoryID"], 
                    ImageUrl: reader["ImageUrl"].ToString()
                )
            );
        }

       
        /// <summary>
        /// Updates an existing cake in the database.
        /// </summary>
        /// <param name="cakeToUpdate">CakeDTO with updated cake data.</param>
        /// <returns>True if successful, otherwise false.</returns>
        public static bool UpdateCake(CakeDTO cakeToUpdate)
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
        public static bool DeleteCake(int? cakeId)
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
        /// <returns>A list of CakeDTO objects.</returns>
        public static List<CakeDTO> GetAllCakes()
        {
            return DataAccessHelper.GetAll(
                "sp_GetAllCakes", // Stored procedure name to get all cakes
                reader => new CakeDTO(
                    CakeID: (int)reader["CakeID"],
                    CakeName: reader["CakeName"].ToString(),
                    Description: reader["Description"].ToString(),
                    Price: (decimal)reader["Price"],
                    StockQuantity: (int)reader["StockQuantity"],
                    CategoryID: (int)reader["CategoryID"],  
                    ImageUrl: reader["ImageUrl"].ToString()
                )
            );
        }

     
        /// <summary>
        /// Retrieves all cakes belonging to a specified category.
        /// </summary>
        /// <param name="categoryId">The ID of the category to filter cakes.</param>
        /// <returns>A list of CakeDTO objects if found, otherwise an empty list.</returns>
        public static List<CakeDTO> GetCakesByCategory(int categoryId)
        {
            return DataAccessHelper.GetAll(
                "sp_GetCakesByCategory",  
                "CategoryID",             
                categoryId,               
                reader => new CakeDTO(
                    CakeID: (int)reader["CakeID"],
                    CakeName: reader["CakeName"].ToString(),
                    Description: reader["Description"].ToString(),
                    Price: (decimal)reader["Price"],
                    StockQuantity: (int)reader["StockQuantity"],
                    CategoryID: (int)reader["CategoryID"],  // Adjust based on your needs
                    ImageUrl: reader["ImageUrl"].ToString()
                )
            );
        }

     
        /// <summary>
        /// Retrieves all cakes belonging to a specified category.
        /// </summary>
        /// <param name="categoryName">The Name of the category to filter cakes.</param>
        /// <returns>A list of CakeDTO objects if found, otherwise an empty list.</returns>
        public static List<CakeDTO> GetCakesByCategoryName(string categoryName)
        {
            return DataAccessHelper.GetAll(
                "sp_GetCakesByCategoryName", 
                "CategoryName",              
                categoryName,                
                reader => new CakeDTO(
                    CakeID: (int)reader["CakeID"],
                    CakeName: reader["CakeName"].ToString(),
                    Description: reader["Description"].ToString(),
                    Price: (decimal)reader["Price"],
                    StockQuantity: (int)reader["StockQuantity"],
                    CategoryID: (int)reader["CategoryID"], 
                    ImageUrl: reader["ImageUrl"].ToString()
                )
            );
        }
    }

}