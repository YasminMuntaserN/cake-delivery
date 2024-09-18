using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs
{
    /// <summary>
    /// DTO Used for deleting an order
    /// </summary>
    /// 
    public record OrderDeleteDTO(
        int OrderID
    );

}
