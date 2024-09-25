using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs
{
    /// <summary>
    /// DTO Used for creating a new order
    /// </summary>
    /// 
    public record OrderCreateRequestDTO(
     int CustomerID,
     decimal TotalAmount,
     string PaymentStatus,
     string DeliveryStatus
 );

}
