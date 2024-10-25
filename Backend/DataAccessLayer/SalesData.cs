using CakeDeliveryDTO.SalesDTOs;
using DTOs;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class SalesData
    {


        /// <summary>
        /// Retrieves a list of Sales for each day in the week
        /// </summary>
        /// <returns>List of SalesDTO if found, otherwise an empty list.</returns>
        public static List<SalesDTO> All()
        {
            return DataAccessHelper.GetAll<SalesDTO>(
                "sp_GetSalesForWeek",
                Mappings.MapSalesWithDTOFromReader
            );
        }

      }
}