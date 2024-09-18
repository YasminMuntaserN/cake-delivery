using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs
{
    /// <summary>
    /// DTO Used for retrieving order details. 
    /// </summary>
    /// 

    public record OrderResponseDTO(
        int OrderID,
        int CustomerID,
        DateTime OrderDate,
        decimal TotalAmount,
        string PaymentStatus,
        string DeliveryStatus
    );

}
