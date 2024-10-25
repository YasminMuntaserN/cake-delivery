using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CakeDeliveryDTO.SalesDTOs
{
    /// <summary>
    /// DTO Used for retrieving Sales details  for each day in week
    /// </summary>
    /// 

    public record SalesDTO(
            decimal Sales,
            string Day
        );
}
