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
    public class clsCustomerData
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
                reader => new CustomerDTO(
                CustomerID: (int)reader["CustomerID"],
                FirstName: reader["FirstName"]?.ToString() ?? string.Empty,
                LastName: reader["LastName"]?.ToString() ?? string.Empty,
                FullName: string.Concat(reader["FirstName"]?.ToString(), " ", reader["LastName"]?.ToString()),
                Email: reader["Email"]?.ToString() ?? string.Empty,
                PhoneNumber: reader["PhoneNumber"]?.ToString() ?? string.Empty, 
                Address: reader["Address"]?.ToString() ?? string.Empty,
                City: reader["City"]?.ToString() ?? string.Empty,
                PostalCode: reader["PostalCode"]?.ToString() ?? string.Empty,
                Country: reader["Country"]?.ToString() ?? string.Empty,
                CreatedAt: (DateTime)reader["CreatedAt"]
            )
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
                reader => new CustomerDTO(
                CustomerID: (int)reader["CustomerID"],
                FirstName: reader["FirstName"]?.ToString() ?? string.Empty,
                LastName: reader["LastName"]?.ToString() ?? string.Empty,
                FullName: string.Concat(reader["FirstName"]?.ToString(), " ", reader["LastName"]?.ToString()),
                Email: reader["Email"]?.ToString() ?? string.Empty,
                PhoneNumber: reader["PhoneNumber"]?.ToString() ?? string.Empty, 
                Address: reader["Address"]?.ToString() ?? string.Empty,
                City: reader["City"]?.ToString() ?? string.Empty,
                PostalCode: reader["PostalCode"]?.ToString() ?? string.Empty,
                Country: reader["Country"]?.ToString() ?? string.Empty,
                CreatedAt: (DateTime)reader["CreatedAt"]
            )
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
                 reader => new CustomerDTO(
                CustomerID: (int)reader["CustomerID"],
                FirstName: reader["FirstName"]?.ToString() ?? string.Empty,
                LastName: reader["LastName"]?.ToString() ?? string.Empty,
                FullName: string.Concat(reader["FirstName"]?.ToString(), " ", reader["LastName"]?.ToString()),
                Email: reader["Email"]?.ToString() ?? string.Empty,
                PhoneNumber: reader["PhoneNumber"]?.ToString() ?? string.Empty,
                Address: reader["Address"]?.ToString() ?? string.Empty,
                City: reader["City"]?.ToString() ?? string.Empty,
                PostalCode: reader["PostalCode"]?.ToString() ?? string.Empty,
                Country: reader["Country"]?.ToString() ?? string.Empty,
                CreatedAt: (DateTime)reader["CreatedAt"]
            )
                 );
        }
    }
}