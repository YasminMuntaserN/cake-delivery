using CakeDeliveryDTO.CustomerDTOs;
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
        /// <summary>
        /// Maps an IDataReader to a CustomerDTO object.
        /// </summary>
        /// <param name="reader">The IDataReader instance containing Customer data.</param>
        /// <returns>CustomerDTO object.</returns>
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
                Country: reader["Country"]?.ToString() ?? string.Empty,
                CreatedAt: (DateTime)reader["CreatedAt"]
            );
        }
    }
}
}
