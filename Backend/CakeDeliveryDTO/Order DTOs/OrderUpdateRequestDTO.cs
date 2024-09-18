using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs
{
    /// <summary>
    /// DTO Used for updating an existing order
    /// </summary>
    /// 
    public record OrderUpdateRequestDTO(
        int OrderID,
        int CustomerID,
        decimal TotalAmount,
        string PaymentStatus,
        string DeliveryStatus
    );

}
