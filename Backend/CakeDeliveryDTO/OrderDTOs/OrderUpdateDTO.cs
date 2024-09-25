using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs
{
    /// <summary>
    /// DTO Used for updating an existing order in this dto there is no need to get  OrderDate it will be updated automatically in the database
    /// </summary>
    /// 
    public record OrderUpdateDTO(
        int OrderID,
        int CustomerID,
        decimal TotalAmount,
        string PaymentStatus,
        string DeliveryStatus
    );

}
