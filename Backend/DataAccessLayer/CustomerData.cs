using CakeDeliveryDTO.CustomerDTOs;
using DTOs;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace DataAccessLayer
{
    public class CustomerData
    {
        /// <summary>
        /// Adds a new Customer to the database.
        /// </summary>
        /// <param name="Customer">CustomerCreateDTO with Customer data.</param>
        /// <returns>The new CustomerID if successful, otherwise null.</returns>
        public static int? Add(CustomerCreateDTO Customer)
        {
            return DataAccessHelper.Add(
                "sp_AddCustomer",   
                "NewCustomerID",    
                Customer            
            );
        }


        /// <summary>
        /// Retrieves an Customer by its ID.
        /// </summary>                                                                        
        /// <param name="CustomerId">The ID of the Customer to find.</param>             
        /// <returns>CustomerDTO if found, otherwise null.</returns>                      
        public static CustomerDTO? GetCustomerById(int? CustomerId)
        {                                                                               
            return DataAccessHelper.GetByParameter<CustomerDTO>(                        
                "sp_GetCustomerById",                                                    
                "CustomerID",
                CustomerId,
                Mappings.MapCustomerDTOFromReader
          );
      }

      
        /// <summary>
        /// Retrieves an Customer by its Name.
        /// </summary>                                                                        
        /// <param name="CustomerName">The Name of the Customer to find.</param>             
        /// <returns>CustomerDTO if found, otherwise null.</returns>                      
        public static CustomerDTO? GetCustomerByName(string Name)
        {
            return DataAccessHelper.GetByParameter<CustomerDTO>(
                "sp_GetCustomerByName",
                "FullName",
                Name,
                Mappings.MapCustomerDTOFromReader
          );
        }


        /// <summary>
        /// Updates an existing Customer in the database.
        /// </summary>
        /// <param name="CustomerToUpdate">CustomerDTO with updated Customer data.</param>
        /// <returns>True if successful, otherwise false.</returns>
        public static bool UpdateCustomer(CustomerDTO CustomerToUpdate)
        {
            return DataAccessHelper.Update(
                "sp_UpdateCustomer",  
                CustomerToUpdate      
            );
        }

     
        /// <summary>
        /// Deletes an Customer by its ID.
        /// </summary>
        /// <param name="CustomerId">The ID of the Customer to delete.</param>
        /// <returns>True if successful, otherwise false.</returns>
        public static bool DeleteCustomer(int? CustomerId)
        {
            return DataAccessHelper.Delete(
                "sp_DeleteCustomer",  
                "CustomerID",         
                CustomerId            
            );
        }

       
        /// <summary>
        /// Retrieves all Customers from the database.
        /// </summary>
        /// <returns>A list of CustomerDTO objects.</returns>
        public static List<CustomerDTO> GetAllCustomers()
        {
            return DataAccessHelper.GetAll(
                "sp_GetAllCustomers",
                Mappings.MapCustomerDTOFromReader
                 );
        }
    }
}